using UnityEngine;
using System.Collections;

public class RedCharacterActions : MonoBehaviour {
	bool downPressed = false;
	bool upPressed = false;
	float target = 0;
	float startPosition = 0;
	bool started = false;
	bool reached = false;
	bool canMoveUp = true;
	bool canMoveDown = true;
	public bool isRed = false;
	public bool isBlue = false;
	bool moving = false;
	public static bool nearRedButtonOn = false;
	public bool canMove = true;
	public float speed = 8f;
	// Use this for initialization
	void Start () {
		animation["Walking"].speed = 2f;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!moving && canMove){
			if(isRed){
				transform.rotation = Quaternion.AngleAxis(-90,Vector3.up);
				animation.Play("Idle");
			}
			if(isBlue){
				transform.rotation = Quaternion.AngleAxis(90,Vector3.up);
				animation.Play("Idle");
			}
		}
		
		
		
		
		moving = false;
	}
	
	public void MoveDown(){
		if(canMove){
			animation.Play("Walking");
			upPressed = false;
			downPressed = true;
			moving = true;
			transform.rotation = new Quaternion(0,180,0,0);
			transform.Translate(Vector3.forward*Time.deltaTime*speed);
			//moving = false;
			downPressed = false;
			
		}
	}
	
	public void MoveUp(){
		if(canMove){
			animation.Play("Walking");
			upPressed = true;
			downPressed = false;
			moving = true;
			transform.rotation = Quaternion.identity;
			transform.Translate(Vector3.forward*Time.deltaTime*speed);
			//moving = false;
			upPressed = false;
		}
	}
}
