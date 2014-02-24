using UnityEngine;
using System.Collections;

public class SleepWorldController : MonoBehaviour {


	public GameObject astroid;
	public GameObject sheep;

	public int maxAstroid;
	
	public int xRandom;
	public int yRandom;
	public int zRandom;
	
	private bool createWrold;
	private float maxDistance;
	private bool first;
	private Vector3 playerPosition;
	public int maxSheep;
	private int sheepCount;
	private int astroidCount;

	private int sheepDead;
	
	// Use this for initialization
	void Start () {
		
		
		createWrold = true;
		first = true;

		playerPosition = GameObject.FindWithTag("Player").transform.position;

		
		maxDistance = Vector3.Distance (playerPosition, astroid.transform.position);
		
		maxDistance = maxDistance / 4.9f;

		astroidCount = 0;
		sheepCount = 0;
		sheepDead = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (createWrold) {
			
			CreateWorld();

			print ("sheep count: " + sheepCount);

			print ("astroid count: " + astroidCount);

			createWrold = false;
		}
		
	
		if (sheepCount == sheepDead) {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.FirstLevel();
			
			Application.LoadLevel(1);		
		}
		

	}
	
	private void CreateWorld(){

		for(int i = 5; i < maxAstroid + 5;){

			int sheepNumber = Random.Range(0,4);

			for(int j = 0; j < 4; j++){

				int randomX = Random.Range(3, xRandom);

				int randomY = Random.Range(-yRandom, yRandom);
				int randomZ = Random.Range(3, zRandom);

				if(astroidCount < maxAstroid){

					float newX;
					float newY = playerPosition.y + (randomY * (maxDistance));
					float newZ;

					if(j == 0 || j == 1){

						randomX = Random.Range(-xRandom, xRandom);

						newX = playerPosition.x + ((randomX * (maxDistance)) * i);

						if(j == 0){
							newZ = playerPosition.z + ((randomZ * (maxDistance)) * i);
						}
						else{
							newZ = playerPosition.z - ((randomZ * (maxDistance)) * i);
						}
					}
					else{

						randomZ = Random.Range(-zRandom, zRandom);
						newZ = playerPosition.z + ((randomZ * (maxDistance)) * i);

						if(j == 2){
							newX = playerPosition.x + ((randomX * (maxDistance)) * i);
						}
						else{
							newX = playerPosition.x - ((randomX * (maxDistance)) * i);
						}
					}
				

					
					
					
					Vector3 position = new Vector3 (newX, newY, newZ);

					if(j == sheepNumber){
						GameObject newObject = (GameObject) Instantiate (sheep, position , sheep.transform.rotation);
						sheepCount += 1;
					}

					else{
						GameObject newObject = (GameObject) Instantiate (astroid, position , astroid.transform.rotation);
						astroidCount += 1;
					}


					
					
				}
			
				


			}

			i++;
			
		}
	

	}

	void OnGUI(){
		GUI.Label(new Rect(20, 20, Screen.width, Screen.height), "Sheep: " + sheepDead + " / " + sheepCount);
	}

	public void sheepKilled(){
		sheepDead += 1;
	}

}