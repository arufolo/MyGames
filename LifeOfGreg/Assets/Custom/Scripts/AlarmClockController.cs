using UnityEngine;
using System.Collections;

public class AlarmClockController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.NextLevel();
			
			Application.LoadLevel(1);
		}

	}
}
