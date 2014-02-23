using UnityEngine;
using System.Collections;

public class SampleAI : MonoBehaviour {
	public GameScript gameScript;
	public float bombSpeed;
	public float playerSpeed;
	public bool[] beltDirections;
	public Vector3[] buttonLocations;
	int belt;
	

	// Start is called once when the game runs
	void Start () {
		//gameScript holds a lot of functions to get information about the state of the game
		//use gameScript to move your player
		gameScript = this.GetComponent("GameScript") as GameScript;
		
		//how fast the bombs move
		bombSpeed = gameScript.GetBombSpeed();
		
		//how fast the player moves
		playerSpeed = gameScript.GetPlayerSpeed();
		
		//an array of Vector3 for each buttons on your side
		buttonLocations = gameScript.GetButtonLocations();
	}
	
	
	// Update is called once per frame
	void Update () {
		//Gets the state of the belts
		beltDirections = gameScript.GetBeltDirection();
		
		//Figure out which belts need to be engaged
		for(int i = 0; i < beltDirections.Length;i++){
			if(beltDirections[i] == false){
				belt = i;
			}		
		}
		
		//Move toward next belt and push button
		if(buttonLocations[belt].z < transform.position.z){
			gameScript.MoveDown();
			gameScript.Push();
		}
		else{
			gameScript.MoveUp();
			gameScript.Push();
		}
		
	}
}
