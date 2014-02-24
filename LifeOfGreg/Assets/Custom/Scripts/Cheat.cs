using UnityEngine;
using System.Collections;

public class Cheat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		DontDestroyOnLoad (this.gameObject);

		if(Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.LeftShift)){
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.NextLevel();
			
			Application.LoadLevel(1);
			
		}

		if(Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.LeftShift)){
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
			
		}

		if(Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.LeftShift)){
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.FirstLevel();

			Application.LoadLevel(1);
		}
	}
}
