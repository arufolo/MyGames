using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public static int score = 0;					// The player's score.
	public static float timer = 100f;

	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}


	void Update ()
	{
		//Checks time to see if difficult should change
		if (timer < 75f)
			VeggieSpawning.maxSpawnTime = 4.5;
		if (timer < 60f)
			VeggieSpawning.maxSpawnTime = 4;
		if (timer < 50f)
			VeggieSpawning.maxSpawnTime = 3.5;
		if (timer < 35f)
			VeggieSpawning.maxSpawnTime = 3;
		if (timer < 25f)
			VeggieSpawning.maxSpawnTime = 2;
		timer = timer - Time.deltaTime;

		if (score != 20) 
		{
			// Set the score text.
			guiText.text = "Score: " + score + "/20" + "\nTime Remaining: " + Mathf.Round (timer);
		}
		if (score >= 20) 
		{
			guiText.text = "Successful \n Nutritious \nLunch! \n Press Enter to go Back to work!";
			if(Input.GetKey(KeyCode.Return))
			{
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.NextLevel();
				
				Application.LoadLevel(1);
			}
		}
		if(score <=19 && timer <= 0)
		{
			guiText.text = "Horrible Lunch Break! \n Press Y to take another, \nPress N to go back \n to work Hungry...";
			if(Input.GetKey(KeyCode.Y))
			{
				Debug.Log("This Should reload the level");
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.SameLevel();
				
				Application.LoadLevel(1);
			}
			if(Input.GetKey(KeyCode.N))
			{
				Debug.Log("This should load the next Level");
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.NextLevel();
				
				Application.LoadLevel(1);
			}
		}

	}

}
