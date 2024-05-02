using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    private float playersTotalXpos;
    private float playersTotalZpos;

    private float cameraX;
    private float cameraZ;
    private Vector3 cameraPos;

    public List<GameObject> players = new List<GameObject>();
  
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //Resets temp variables to 0
        playersTotalXpos = 0;
        playersTotalZpos = 0;

        //Collects all players position data
		foreach (GameObject player in players)
		{
			playersTotalXpos += player.transform.position.x;
			playersTotalZpos += player.transform.position.z;
		}
        //Calculates the center points and positions the camera
		cameraX = playersTotalXpos / players.Count;
		cameraZ = playersTotalZpos / players.Count;
		cameraPos = new Vector3(cameraX, 5, cameraZ);
		this.transform.position = cameraPos;
	}
}
