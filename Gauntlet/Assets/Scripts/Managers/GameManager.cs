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
       if(Input.GetKeyDown(KeyCode.Keypad1))
		{
			playerCount[0].gameObject.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			playerCount[1].gameObject.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			playerCount[2].gameObject.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			playerCount[3].gameObject.SetActive(true);
		}

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
