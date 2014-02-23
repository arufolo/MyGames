using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {
	public GameScript gameScript;
	public float bombSpeed;
	public float playerSpeed;
	public Vector3[] buttonLocations;
	public bool[] beltDirections;
	int belt;
	int blah =0; 
	
	//MY INITIALIZATIONS HERE!!!!
	
	//To Generate a Random factor in belt selection 
	int randomBelt; 
	
	//Weights of belts 
	float[] weight; 
	
	//Bomb Locations
	float[] bombLocation;
	
	//Booleans for high priority belts 
	bool[] high;
	bool[] medium;
	bool[] low;
	
	// Start is called once when the game runs
	void Start () {
		
		//array declarations
		weight = new float[8];
		high = new bool[8];
		medium = new bool[8];
		low = new bool[8];
		//gameScript holds a lot of functions to get information about the state of the game
		//use gameScript to move your player
		gameScript = this.GetComponent("GameScript") as GameScript;
		
		//how fast the bombs move
		bombSpeed = gameScript.GetBombSpeed();
		
		//how fast the player moves
		playerSpeed = gameScript.GetPlayerSpeed();
		
		//an array of Vector3 for each buttons on your side
		buttonLocations = gameScript.GetButtonLocations();
		
		//First random belt to head towards 
		randomBelt = Random.Range(0, 8);
		belt = randomBelt;
		
		 for(int i = 0; i < 8; i++){
			weight[i] = 0;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
		//Gets the state of the belts
		beltDirections = gameScript.GetBeltDirection();
		
		//Gets the state of the bomb locations
		bombLocation = gameScript.GetBombLocation();
		
		//Figure out the current weight of each belt and find any high priority
		for(int i = 0; i < beltDirections.Length; i++)
		{
			if(bombLocation[i] < 50 && bombLocation[i] > 37.5 )
			{
				weight[i] = 10;
			}
			if(bombLocation[i] < 37.5 && bombLocation[i] >= 23 )
			{
				weight[i] = 20;
			}
			if(bombLocation[i] < 23 && bombLocation[i] > 12.5 && beltDirections[i] == false)
			{
				weight[i] = 30;
			}
			if(bombLocation[i] <=12.5 && beltDirections[i] == false)
			{
				weight[i] = 40;
			}	
			if(weight[i] == 40)
			{
				high[i] = true;
				medium[i] = false;
				low[i] = false;
			}
			else if(weight[i] == 30)
			{
				high[i] = false;
				medium[i] = true;
				low[i] = false;
			}
			else if(weight[i] == 20 )
			{
				high[i] = false;
				medium[i] = false;
				low[i] = true;
			}
			
		}
		
		if(beltDirections[belt] == false && high[belt] == true)
		{
							
			if(buttonLocations[belt].z < transform.position.z)
			{
				gameScript.MoveDown();
				gameScript.Push();	
				
			}
			else if(buttonLocations[belt].z > transform.position.z)
			{
				gameScript.MoveUp();
				gameScript.Push();	
											
			}
		}
		else if(beltDirections[belt] == false && medium[belt] == true && !checkHighPriorityBelt())
		{
			
			if(buttonLocations[belt].z < transform.position.z)
			{
				if(checkHighPriorityBelt() == true)
				{
					for(int e = 0; e <beltDirections.Length; e++)
					{
						if(high[e] == true)
						{
							belt = e;
							break;
						}
					}
				}
				else
				{
					gameScript.MoveDown();
					gameScript.Push();	
				}
				
			}
			else if(buttonLocations[belt].z > transform.position.z)
			{
				if(checkHighPriorityBelt() == true)
				{
					for(int e = 0; e <beltDirections.Length; e++)
					{
						if(high[e] == true)
						{
							belt = e;
							break;
						}
					}
				}
				else
				{
					gameScript.MoveUp();
					gameScript.Push();
				}
											
			}
		}
		else if(beltDirections[belt] == false && low[belt] == true)
		{
			for(int t = 0; t <beltDirections.Length; t++)
			{
				if(high[t] == true)
				{
					belt = t;
					break;
				}	
					
			}	
			if(buttonLocations[belt].z < transform.position.z)
			{				
				gameScript.MoveDown();
				gameScript.Push();	
								
			}
				for(int t = 0; t <beltDirections.Length; t++)
				{
					if(high[t] == true)
					{
						belt = t;
						break;
					}
				}
								
			if(buttonLocations[belt].z > transform.position.z)
			{				
				gameScript.MoveUp();
				gameScript.Push();
															
			}
		}
		
		else
		{
			randomBelt = Random.Range(0,8);
			belt = randomBelt;
			
		}
			
			
		
	}
	
	public bool checkHighPriorityBelt()
	{
		for(int j = 0; j < beltDirections.Length; j++)
		{
			if(bombLocation[j] <=12.5 && beltDirections[j] == false )
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
		
		return false;
	}
	public bool checkMediumPriorityBelt()
	{
		for(int k = 0; k < beltDirections.Length; k++)
		{
			if(bombLocation[k] <=23 && bombLocation[k] > 12.5 && beltDirections[k] == false )
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
		
		return false;
	}
	public bool checkLowPriorityBelt()
	{
		for(int h = 0; h < beltDirections.Length; h++)
		{
			if(bombLocation[h] <=37.5 && bombLocation[h] > 27 )
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
		
		return false;
	}
}
