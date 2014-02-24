using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WakeUpController : MonoBehaviour {

	public GameObject cloud;
	public GameObject alarmClock;
	public GameObject bedObject;
	public int maxCloud;

	public int xRandom;
	public int yRandom;

	private bool createWrold;
	private float maxDistance;
	private Vector3 playerPosition;

	private GameObject previousPlatform;



	// Use this for initialization
	void Start () {

	
		createWrold = true;


		previousPlatform = cloud;

		maxDistance = Vector3.Distance (bedObject.transform.position, cloud.transform.position);

		maxDistance = maxDistance / 6f;


		playerPosition = GameObject.FindWithTag("Player").transform.position;

	}
	
	// Update is called once per frame
	void Update () {


		if (createWrold) {

			CreateWorld();

			createWrold = false;
		}

		playerPosition = GameObject.FindWithTag("Player").transform.position;

		if (playerPosition.y < (cloud.transform.position.y - 5)) {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);		
		}
	}

	private void CreateWorld(){
		for(int i = 0; i < maxCloud;){

			int randomX = Random.Range(-xRandom, xRandom);
			int randomY = Random.Range(1, yRandom);

			float newX = previousPlatform.transform.position.x + (randomX * (maxDistance));
			float newZ = previousPlatform.transform.position.z + (randomY * (maxDistance));

			Vector3 position = new Vector3 (newX, previousPlatform.transform.position.y, newZ);
			
			
			if(i < maxCloud - 1){

					

					GameObject newObject = (GameObject) Instantiate (cloud, position , cloud.transform.rotation);

					previousPlatform = newObject;

					

			}

			else{
				Instantiate (alarmClock, position , alarmClock.transform.rotation);
			}

			i++;

		}
	}
	

}
