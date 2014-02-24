using UnityEngine;
using System.Collections;

public class ChairReset : MonoBehaviour {

	public GameObject countDown; 

	public GameObject cs;

	public static bool lose = false;
	public static bool win = false;

	// Use this for initialization
	void Start () {

		lose = false; 
		win = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.R)) 
		{

			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
		}

		if (win == true) 
		{

			guiText.text = "YOU WON! Your score was: " + Mathf.Round (ChairScore.totalScore) + "\nWould you like to try again? \n Y = yes || N = No";
			if(Input.GetKey(KeyCode.Y))
			{
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.SameLevel();
				
				Application.LoadLevel(1);
			}
			if(Input.GetKey(KeyCode.N))
			{
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.NextLevel();
				
				Application.LoadLevel(1);
			}
		
		}
		else if (lose == true) 
		{
			guiText.text = "YOU ARE A LOSER! \n Would you like to try again? \n Y = yes || N = No";
			if(Input.GetKey(KeyCode.Y))
			{
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.SameLevel();
				
				Application.LoadLevel(1);
			}
			if(Input.GetKey(KeyCode.N))
			{
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.NextLevel();
				
				Application.LoadLevel(1);
			}
		}
		else
						guiText.text = "";
	
	}
	
}
