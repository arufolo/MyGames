using UnityEngine;
using System.Collections;

public class PlantSpawn : MonoBehaviour {

	public GameObject[] veggieSprites;
	public GameObject Player;
	public Vector3 addedPosition = new Vector3(0,0,0);
	int random;
	VeggieSpawning vs = new VeggieSpawning();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerControl.upPress && Plant.onPlant && !PlayerControl.hasVegetable) 
		{
			PlayerControl.hasVegetable = true;	
			Plant.onPlant = false; 
			giveVeggie();

		}
	
	}

	public void giveVeggie()
	{
		random = Random.Range(0 , veggieSprites.Length);
		if (random == 9) {
						Veggie.isBurger = true;
				} else
						Veggie.isBurger = false;
		(Instantiate (veggieSprites[random], (Player.transform.position+addedPosition), transform.rotation) as GameObject).transform.parent = Player.transform;
		vs.destroyPlants ();
	}
}
