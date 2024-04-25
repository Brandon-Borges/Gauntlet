using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playersOnExit;
    private int nextScene=1;
    private AudioSource currentAudio;
    public AudioClip[] rulesAudio;
	public AudioClip[] commentsAudio;
	public AudioClip[] lowLifeAudio;


	private void Awake()
	{
		currentAudio = GetComponent<AudioSource>();
	}
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
        SceneManager.LoadScene(nextScene);
        nextScene++;
    }
    private void playRulesAudio()
    {
        currentAudio.clip = rulesAudio[Random.Range(0, rulesAudio.Length)];
        currentAudio.PlayOneShot(currentAudio.clip);
    }
    private void playLowLifeAudio()
    {
        currentAudio.clip = lowLifeAudio[Random.Range(0,lowLifeAudio.Length)];
        currentAudio.PlayOneShot(currentAudio.clip);
    }
    private void playCommentsAudio()
    {
        currentAudio.clip = commentsAudio[Random.Range(0, commentsAudio.Length)];
        currentAudio.PlayOneShot(currentAudio.clip);
    }
}
