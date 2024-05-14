using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PathFinder : MonoBehaviour
{
	
	public static PathFinder Instance;
	public bool FindDistance = false;
	public int gridRows = 40;
	public int gridColumns = 10;
	public int scale = 1;
	public GameObject gridPrefab;
	public GameObject wallPrefab;
	public Vector3 leftBottomLocation;
	public GameObject[,] gridArray;
	public int startX = 0;
	public int startY = 0;
	public int endX = 2;
	public int endY = 2;
	public List<GameObject> path = new List<GameObject>();

	private void Awake()
	{
		if (Instance != null)
			Destroy(this);
		else
			Instance= this;

		gridArray = new GameObject[gridColumns, gridRows];
		if (gridPrefab)
			GenerateGrid();
		else
			Debug.Log("missing gridPrefab");
	}
	private void Update()
	{
		if(FindDistance)
		{
			SetDistance();
			SetPath();
			FindDistance= false;
		}
	}
	//creates the game objects used for pathfinding
	void GenerateGrid()
	{
		//Generate Grid of pathfinding objects
		for (int i = 0; i<gridColumns; i++)
		{
			for (int j = 0; j <	gridRows; j++)
			{
				GameObject obj = Instantiate(gridPrefab, new Vector3(leftBottomLocation.x + scale * i, leftBottomLocation.y, leftBottomLocation.z + scale * j), Quaternion.identity);
				obj.transform.SetParent(gameObject.transform);
				obj.GetComponent<GridStats>().x = i;
				obj.GetComponent<GridStats>().y = j;
				gridArray[i, j] = obj;
			}
		}
		// iterates through the list, and creates walls on the outer edge
		for (int i = 0; i < gridColumns; i++)
		{
			Instantiate(wallPrefab, gridArray[i, 0].gameObject.transform.position, Quaternion.identity);
			Destroy(gridArray[i, 0].gameObject);	
		}
		for (int i = 0; i < gridColumns; i++)
		{
			Instantiate(wallPrefab, gridArray[i, gridRows-1].gameObject.transform.position, Quaternion.identity);
			Destroy(gridArray[i, gridRows-1].gameObject);
		}
		for (int i = 0; i < gridRows; i++)
		{
			Instantiate(wallPrefab, gridArray[0, i].gameObject.transform.position, Quaternion.identity);
			Destroy(gridArray[0, i].gameObject);
		}
		for (int i = 0; i < gridRows; i++)
		{
			Instantiate(wallPrefab, gridArray[gridColumns - 1,i ].gameObject.transform.position, Quaternion.identity);
			Destroy(gridArray[gridColumns - 1, i].gameObject);
		}
		switch (GameManager.Instance.nextScene)
		{
			case 1:
				for (int i = 0; i < 35; i++)
				{
					Instantiate(wallPrefab, gridArray[15, i+15].gameObject.transform.position, Quaternion.identity);
					Destroy(gridArray[gridColumns - 1, i].gameObject);
					gridArray[gridColumns - 1, i] = null;
				}
				for (int i = 5; i > 0; i--)
				{
					Instantiate(wallPrefab, gridArray[i+10, 14].gameObject.transform.position, Quaternion.identity);
					Destroy(gridArray[i+10, 14].gameObject);
					gridArray[i+10, 14] = null;
				}
				for (int i = 10; i > 0; i--)
				{
					Instantiate(wallPrefab, gridArray[11, i+3].gameObject.transform.position, Quaternion.identity);
					Destroy(gridArray[11, i+3].gameObject);
					gridArray[11, i+3] = null;
				}
				return;
			default:
				break;
		}
	}
	//iterates through all the steps that are required to get to the end point
	void SetDistance()
	{
		InitialSetUp();
		int x = startX;
		int y = startY;
		int[] testArray = new int [gridRows * gridColumns];
		for (int step = 1; step < gridRows*gridColumns; step++)
		{
			foreach(GameObject obj in gridArray)
			{
				if(obj&&obj.GetComponent<GridStats>().visited == step-1)
					TestFourDirections(obj.GetComponent<GridStats>().x, obj.GetComponent<GridStats>().y,step);
			}
		}
	}
	//Determines if the point can be reached and creates a list of game objects on the path from the start to the end
	public List<GameObject> SetPath()
	{
		SetDistance();
		int step;
		int x = endX;
		int y = endY;
		List<GameObject> tempList = new List<GameObject>();
		path.Clear();
		if (gridArray[endX, endY] && gridArray[endX,endY].GetComponent<GridStats>().visited >0)
		{
			path.Add(gridArray[x, y]);
			step = gridArray[x,y].GetComponent<GridStats>().visited -1;
		}
		else
		{
			Debug.Log("Can't reach targeted location" + gridArray[x, y].GetComponent<GridStats>().visited);
			return null;
		}
		for (int i = step; step > -1; step--)
		{
			if(TestDirection(x,y,step,1))
			{
				tempList.Add(gridArray[x,y+1]);
			}
			if (TestDirection(x, y, step, 2))
			{
				tempList.Add(gridArray[x+1, y]);
			}
			if (TestDirection(x, y, step, 3))
			{
				tempList.Add(gridArray[x, y - 1]);
			}
			if (TestDirection(x, y, step, 4))
			{
				tempList.Add(gridArray[x-1, y]);
			}
			GameObject tempObj = FindClosest(gridArray[endX, endY].transform, tempList);
			path.Add(tempObj);
			x = tempObj.GetComponent<GridStats>().x;
			y = tempObj.GetComponent<GridStats>().y;
			tempList.Clear();
		}
		return path;
	
	}
	// sets the values of the grid to -1 to denote they have not been visited
	void InitialSetUp()
	{
		foreach(GameObject obj in gridArray)
		{
			if(obj != null)
			obj.GetComponent<GridStats>().visited = -1;
		}
		gridArray[startX,startY].GetComponent<GridStats>().visited=0;
	}
	// checks the four directions as posibilites to reach the end point
	bool TestDirection(int x, int y, int step, int direction)
	{
		// direction tells which case to use: 1 = UP: 2 = Right: 3 = Down, 4 = Left
		switch(direction)
		{
			case 1:
				if (y + 1 < gridRows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridStats>().visited == step)
					return true;
				else
					return false;
			case 2:
				if (x + 1 < gridColumns && gridArray[x+1, y] && gridArray[x+1, y].GetComponent<GridStats>().visited == step)
					return true;
				else
					return false;
			case 3:
				if (y -1 >-1 && gridArray[x, y -1] && gridArray[x, y-1].GetComponent<GridStats>().visited == step)
					return true;
				else
					return false;
			case 4:
				if (x-1 > -1 && gridArray[x-1, y] && gridArray[x-1, y].GetComponent<GridStats>().visited == step)
					return true;
				else
					return false;


		}
		return false;
	}

	void TestFourDirections(int x, int y, int step)
	{
		if (TestDirection(x, y, -1, 1))
			SetVisited(x, y + 1, step);
		if (TestDirection(x, y, -1, 2))
			SetVisited(x+1, y, step);
		if (TestDirection(x, y, -1, 3))
			SetVisited(x, y - 1, step);
		if (TestDirection(x, y, -1, 4))
			SetVisited(x-1, y, step);
	}
	// marks a space as visited
	void SetVisited(int x, int y, int step)
	{
		if (gridArray[x,y])
			gridArray[x,y].GetComponent<GridStats>().visited = step;
	
	}
	// Finds the optimal path to the target location
	GameObject FindClosest(Transform targetLocation, List<GameObject> List)
	{
		float currentDistance = scale * gridRows * gridColumns;
		int indexNumber = 0;
		for (int i = 0; i < List.Count; i++)
		{
			if (Vector3.Distance(targetLocation.position, List[i].transform.position)< currentDistance)
			{
				currentDistance = Vector3.Distance(targetLocation.position, List[i].transform.position);
				indexNumber = i;
			}
		}
		return List[indexNumber];
	}

}

