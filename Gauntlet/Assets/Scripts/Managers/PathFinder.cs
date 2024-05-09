using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class PathFinder : MonoBehaviour
{
	public int gridRows = 10;
	public int gridColumns = 10;
	public int scale = 1;
	public GameObject gridPrefab;
	public Vector3 leftBottomLocation;
	public GameObject[,] gridArray;
	public int startX = 0;
	public int startY = 0;
	public int endX = 2;
	public int endY = 2;

	private void Awake()
	{
		gridArray = new GameObject[gridColumns, gridRows];
		if (gridPrefab)
			GenerateGrid();
		else
			Debug.Log("missing gridPrefab");
	}
	void GenerateGrid()
	{
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
	}
	void InitialSetUp()
	{
		foreach(GameObject obj in gridArray)
		{
			obj.GetComponent<GridStats>().visited = -1;
		}
		gridArray[startX,startY].GetComponent<GridStats>().visited=0;
	}
	
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
				if (y -1 < -1 && gridArray[x, y -1] && gridArray[x, y-1].GetComponent<GridStats>().visited == step)
					return true;
				else
					return false;
			case 4:
				if (x-1 < -1 && gridArray[x-1, y] && gridArray[x-1, y].GetComponent<GridStats>().visited == step)
					return true;
				else
					return false;


		}
		return false;
	}

}

