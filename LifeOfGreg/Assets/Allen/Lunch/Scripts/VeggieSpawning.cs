using UnityEngine;
using System.Collections;

public class VeggieSpawning : MonoBehaviour {

	//Game Object Array to hold all spawn points
	GameObject[] spawnPoints;
	GameObject[] plants;

	GameObject player;

	public GameObject plant;

	//Random int to spawn veggies
	int random = 0; 

	//Holds the Time
	private double spawnTimer;

	//Ups the difficulty
	public static double maxSpawnTime = 5; 

	// Use this for initialization
	void Start () {

		//Fills the Arrays with these tags
		spawnPoints = GameObject.FindGameObjectsWithTag("SpawnLocation");
		player = GameObject.FindGameObjectWithTag("Player");

		//Creates first random spawn location	
		random = Random.Range(0 , spawnPoints.Length);
		spawnNewVeggies (spawnPoints[random].transform.position);
	
	}
	
	// Update is called once per frame
	void Update () {

		spawnTimer += Time.deltaTime;

		if (spawnTimer >= maxSpawnTime) 
		{
			random = Random.Range(0 , spawnPoints.Length);
			destroyPlants ();
			spawnNewVeggies (spawnPoints[random].transform.position);
		}
	
	}

	public void spawnNewVeggies(Vector3 position)
	{
		Instantiate (plant, position, transform.rotation);
		spawnTimer = 0;
	}

	public void destroyPlants()
	{
		plants = GameObject.FindGameObjectsWithTag("Plant");
		for (int i=0; i<plants.Length; i++) 
		{
						
			Destroy (plants[i]);
		}
	}
}
