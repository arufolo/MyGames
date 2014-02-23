using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	public bool isRed = false;
	public bool isBlue = false;
	private RedCharacterActions redCharacter;
	private BlueCharacterActions blueCharacter;
	public GameObject[] blueButtons;
	public GameObject[] redButtons;
	public Vector3[] locationForButton;
	public bool[] directionForBelt;
	public bool warnings = false;
	private Transform otherCharacter;
	private GameObject belt;
	private float playerSpeed;
	private float bombSpeed;
	
	// Use this for initialization
	void Start () {
		if(isBlue){
			blueCharacter = this.GetComponent("BlueCharacterActions") as BlueCharacterActions;
			//blueButtons = GameObject.FindGameObjectsWithTag("BlueButton");
			otherCharacter = GameObject.Find("RedCharacter").transform;
		}
		else if(isRed){
			redCharacter = this.GetComponent("RedCharacterActions") as RedCharacterActions;
			//redButtons = GameObject.FindGameObjectsWithTag("RedButton");
			otherCharacter = GameObject.Find("BlueCharacter").transform;
		}
		locationForButton = GetButtonLocations();
		Warnings();
	}
	
	
	// Update is called once per frame
	void Update () {
	}
	
	public void MoveUp(){
		if(isBlue){
			blueCharacter.MoveUp();
		}
		else if(isRed){
			redCharacter.MoveUp();
		}
	}
	
	public void MoveDown(){
		if(isBlue){
			blueCharacter.MoveDown();
		}
		else if(isRed){
			redCharacter.MoveDown();
		}
	}
	
	public void Push(){
		if(isBlue){
			foreach(GameObject button in blueButtons){
				BlueButtonForAi thisButton = button.GetComponent("BlueButtonForAi") as BlueButtonForAi;
				thisButton.Push();
			}
		}
		else if(isRed){
			foreach(GameObject button in redButtons){
				RedButtonForAi thisButton = button.GetComponent("RedButtonForAi") as RedButtonForAi;
				thisButton.Push();
			}
		}
	}
	
	public Vector3 GetCharacterLocation(){
		return this.transform.position;
	}
	
	public Vector3 GetOpponentLocation(){
		return otherCharacter.position;
	}
	
	public Vector3[] GetButtonLocations(){
		if(isBlue){
			Vector3[] buttons = new Vector3[8];
			int i = 0;
			foreach(GameObject button in redButtons){
				buttons[i] = button.transform.position;
				i++;
			}
			return buttons;
		}
		else if(isRed){
			Vector3[] buttons = new Vector3[8];
			int i = 0;
			foreach(GameObject button in redButtons){
				buttons[i] = button.transform.position;
				i++;
			}
			return buttons;
		}
		return null;
	}
	
	public bool[] GetBeltDirection(){
		if(isBlue){
			int i = 0;
			bool[] belt = new bool[8];
			foreach(GameObject button in blueButtons){
				BlueButtonForAi thisButton = button.GetComponent("BlueButtonForAi") as BlueButtonForAi;
				belt[i] = thisButton.on;
				i++;
			}
			return belt;
		}
		else if(isRed){
			int i = 0;
			bool[] belt = new bool[8];
			foreach(GameObject button in redButtons){
				RedButtonForAi thisButton = button.GetComponent("RedButtonForAi") as RedButtonForAi;
				belt[i] = thisButton.on;
				i++;
			}
			return belt;
		}
		return null;
	}
	
	public float[] GetBombLocation(){
		int i = 0;
		float[] location = new float[8];
		Transform bomb;
		if(isRed){
			foreach(GameObject button in redButtons){
				bomb = button.transform.parent.GetChild(1);
				location[i] = Vector3.Distance(bomb.position, button.transform.position);
				i++;
			}
		}
		else if(isBlue){
			foreach(GameObject button in blueButtons){
				bomb = button.transform.parent.GetChild(1);
				location[i] = Vector3.Distance(bomb.position, button.transform.position);
				i++;
			}
		}
		return location;
	}
	
	public float GetPlayerSpeed(){
		return 8f;
	}
	
	public float GetBombSpeed(){
		belt = GameObject.Find ("Belt1");
		BeltScript beltScript = belt.GetComponent("BeltScript") as BeltScript;
		return beltScript.speed;
	}
	
	public void Warnings(){
		if(warnings){
			
			Debug.Log("MoveUp(); Moves the character up by a fixed amount. Place in Update Function.");
			Debug.Log("MoveDown(); Moves the character down by a fixed amount. Place in Update Function.");
			Debug.Log("Push(); This presses the switch.");
			Debug.Log("GetCharacterLocation(); Returns the transform.position of your character.");
			Debug.Log("GetOpponentLocation(); Returns the transform.position of your opponent.");
			Debug.Log("GetButtonLocations(); Returns a Vector3 array of the button locations for your side.");
			Debug.Log("GetBeltDirection(); Returns whether the belt is coming in your direction. True for coming towards you, false for going towards enemy.");
			Debug.Log("GetBombLocation(); Returns distance of bombs in respect to the button that activates the belt for that bomb. " +
				"Warning, bombs explode at ~2.0f");
			Debug.Log("GetPlayerSpeed(); Returns the player movement speed. This is a constant float value");
			Debug.Log("GetBombSpeed(); Returns the bomb(belt) movement speed. This is a constant float value");
		}
	}
}
