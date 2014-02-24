using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
		}
			
	}
}
