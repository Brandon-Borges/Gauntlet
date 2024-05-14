using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public int StartX;
    public int StartY;
    public bool foundPlayer = false;
    public float FollowSpeed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(foundPlayer)
        {
			StartCoroutine("nextStep");
			foundPlayer = false;
        }
    }
    public void FollowPath()
    {
		PathFinder.Instance.endX= StartX;
        PathFinder.Instance.endY= StartY;

		
        StartCoroutine("nextStep");
       
    }
    public IEnumerator nextStep()
    {
		List<GameObject> path = PathFinder.Instance.SetPath();
		for (int i = 0; i < path.Count; i++)
        {
            transform.position= path[i].transform.position;
       
        yield return new WaitForSeconds(FollowSpeed);
		


		 StartX = path[i].GetComponent<GridStats>().x;
		 StartY = path[i].GetComponent<GridStats>().y;
		  }
		FollowPath();

		yield return null;
    }
}
