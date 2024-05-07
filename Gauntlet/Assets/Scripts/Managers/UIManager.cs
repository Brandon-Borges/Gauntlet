using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Grabs references to the score Text in the UI Canvas
    [SerializeField] private TMP_Text P1ScoreText;
	[SerializeField] private TMP_Text P2ScoreText;
	[SerializeField] private TMP_Text P3ScoreText;
	[SerializeField] private TMP_Text P4ScoreText;

	//Grabs references to the health Text in the UI Canvas
	[SerializeField] private TMP_Text P1healthText;
	[SerializeField] private TMP_Text P2healthText;
	[SerializeField] private TMP_Text P3healthText;
	[SerializeField] private TMP_Text P4healthText;

	[SerializeField] private TMP_Text LevelText;
	public UIManager Instance;

	//Naration Text variables
	public TextMeshProUGUI textComponent;
	public string[] GeneralMessages;
	public string[] LowLifeMessages;

	// Start is called before the first frame update
	void Start()
    {
		//checks scene to make sure only one is present, if not then makes it a singleton
		
		
		
		{ Instance= this; }
		textComponent.text = string.Empty;
		InvokeRepeating("NextMessage", 5f, 30f);
		InvokeRepeating("RemoveText", 10f, 30f);
	}

	public void updateHealthText(int playerNum, int health)
	{
		switch(playerNum)
		{
			case 0:
				P1healthText.text = health.ToString();
				break;
			case 1:
				P2healthText.text = health.ToString();
				break;
			case 2:
				P3healthText.text = health.ToString();
				break;
			case 3:
				P4healthText.text = health.ToString();
				break;
		}
		if(health <= 200)
		{
			textComponent.text = LowLifeMessages[playerNum];
			
		}

	}
	public void updateScoreText(int playerNum, int score)
	{
		switch (playerNum)
		{
			case 0:
				P1ScoreText.text = score.ToString();
				break;
			case 1:
				P2ScoreText.text = score.ToString();
				break;
			case 2:
				P3ScoreText.text = score.ToString();
				break;
			case 3:
				P4ScoreText.text = score.ToString();
				break;
		}
	}
	public void updateLevelText(int level)
	{
		LevelText.text = level.ToString();
	}

	private void NextMessage()
	{
		int nextMessage = Random.Range(0,GeneralMessages.Length);
		textComponent.text = GeneralMessages[nextMessage];	
	}
	private void RemoveText()
	{
		textComponent.text = string.Empty;
	}

}
