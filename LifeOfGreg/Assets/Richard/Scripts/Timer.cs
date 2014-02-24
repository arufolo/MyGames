using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
    float startTime;
    float timeRemaining;
    int minutes;
    private ScoreKeep score;

	// Use this for initialization
	void Start () 
    {
        startTime = 1f;
        score = GameObject.Find("PointsText").GetComponent<ScoreKeep>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Countdown();
        ShowTime();
        Debug.Log(timeRemaining);
        if (score.getScore() >= 10)
        {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.NextLevel();
			
			Application.LoadLevel(1);
        }
		/*
        else if (minutes >= 5 && score.getScore() < 10)
        {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
        }
        */
	}

    void Countdown()
    {
        timeRemaining = startTime + Time.time*5;       
    }

    void ShowTime()
    {        
        int seconds;
        string timeString;

        minutes = (int)(timeRemaining / 60);
        seconds = (int)(timeRemaining % 60);
		timeString = "Touch objects to grab. Deliever to co-workers";
        guiText.text = timeString;
    }


}
