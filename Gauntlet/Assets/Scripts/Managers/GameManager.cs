using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playersOnExit;
    public List<GameObject> playerCount;
    public int nextScene=1;
	public static GameManager Instance;



	private void Awake()
	{
		if (Instance != null)
			Destroy(this);
		else
			Instance = this;
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
