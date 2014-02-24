using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Collider")
        {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
        }
    }
}
