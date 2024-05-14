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
	public int activePlayers = 0;


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
       if(Input.GetKeyDown(KeyCode.Keypad0))
		{
			if (activePlayers == 0)
			playerCount[0].gameObject.SetActive(true);
			StartCoroutine("newPlayer");
		}
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			if (activePlayers == 1)
			playerCount[1].gameObject.SetActive(true);
			StartCoroutine("newPlayer");
		}
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			if (activePlayers == 2)
			playerCount[2].gameObject.SetActive(true);
			StartCoroutine("newPlayer");
			
		}
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			if (activePlayers == 3)
			playerCount[3].gameObject.SetActive(true);
			StartCoroutine("newPlayer");
			if (playerCount[2].activeSelf)
			{
				playerCount[3].gameObject.SetActive(true);
			}
		}
			


	}
	public IEnumerator newPlayer()
	{
		if(activePlayers ==1)
	  yield return new WaitForSeconds(1f);
		activePlayers = 2;
		if(activePlayers ==2)
	yield return new WaitForSeconds(1f);
		activePlayers = 3;
		yield return new WaitForSeconds(1f);


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
