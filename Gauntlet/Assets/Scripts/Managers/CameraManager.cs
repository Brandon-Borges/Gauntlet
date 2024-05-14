using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour
{


    private float playersTotalXpos;
    private float playersTotalZpos;

    private float cameraX;
    private float cameraZ;
    public Vector3 cameraPos;
    public static CameraManager Instance;

    public List<GameObject> players = new List<GameObject>();

	private void Awake()
	{
        Instance = this;
	}
	// Update is called once per frame
	void Update()
    {
        Move();
        
        
    }

    private void Move()
    {
        int activePlayers = 0;
        //Resets temp variables to 0
        playersTotalXpos = 0;
        playersTotalZpos = 0;

        //Collects all players position data
		foreach (GameObject player in players)
		{
            if(player.activeSelf)
            {
				playersTotalXpos += player.transform.position.x;
				playersTotalZpos += player.transform.position.z;
                activePlayers++;
			}
			
		}
        //Calculates the center points and positions the camera
		cameraX = playersTotalXpos / activePlayers;
		cameraZ = playersTotalZpos / activePlayers;
		cameraPos = new Vector3(cameraX, 5, cameraZ);
		this.transform.position = cameraPos;
	}
}
