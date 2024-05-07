using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playersOnExit;
    public List<GameObject> playerCount;
    private int nextScene=1;
	



	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
       
    }
    private void loadNextLevel()
    {
        if(playersOnExit == playerCount.Count)
        {
			SceneManager.LoadScene(nextScene);
			nextScene++;
		}
     
    }


}
