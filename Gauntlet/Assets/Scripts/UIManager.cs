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

	// Start is called before the first frame update
	void Start()
    {
		//checks scene to make sure only one is present, if not then makes it a singleton
        if(FindAnyObjectByType<UIManager>())
		Destroy(gameObject);
		else
		{ Instance= this; }
    }

	public void updateHealthText(int playerNum, int health)
	{
		switch(playerNum)
		{
			case 1:
				P1healthText.text = health.ToString();
				break;
			case 2:
				P2healthText.text = health.ToString();
				break;
			case 3:
				P3healthText.text = health.ToString();
				break;
			case 4:
				P4healthText.text = health.ToString();
				break;
		}

	}
	public void updateScoreText(int playerNum, int score)
	{
		switch (playerNum)
		{
			case 1:
				P1ScoreText.text = score.ToString();
				break;
			case 2:
				P2ScoreText.text = score.ToString();
				break;
			case 3:
				P3ScoreText.text = score.ToString();
				break;
			case 4:
				P4ScoreText.text = score.ToString();
				break;
		}
	}
	public void updateLevelText(int level)
	{
		LevelText.text = level.ToString();
	}

  
}