using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	//Determines which player script controls 
	public GameObject player; 
	
	//Determines the starting position of the player 
	public GameObject startingSpot; 
	
	//Move speed adjustable 
	public float moveSpeed = 2;
	
	private bool insideCollider;
	private Collider collision;
	
	//Determines which direction player1 is facing 
	bool oneFacingLeft=false;
	bool oneFacingRight=false; 
	bool oneFacingForward=true; 
	
	//Determines which direction player1 is facing 
	bool twoFacingLeft=false;
	bool twoFacingRight=false; 
	bool twoFacingForward=true; 
	
	bool sendBombPlayer1;
	bool sendBombPlayer2;
	bool movePlayer1Left;
	bool movePlayer1Right;
	bool movePlayer2Left;
	bool movePlayer2Right;

	// Use this for initialization
	void Start () {
		
		oneFacingForward=true;
		insideCollider = false;
		
		sendBombPlayer1 = false;
		sendBombPlayer2 = false;
		movePlayer2Right = false;
		movePlayer2Left = false;
		movePlayer1Right = false;
		movePlayer1Left = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameControl.stop){
		
		if(player.tag=="Player1")
		{
			//rotates the player
			if(oneFacingForward)
			{
								
				if(Input.GetKey(KeyCode.LeftArrow) || movePlayer1Left)
				{				
					player.transform.Rotate(0,-90,0);
					oneFacingLeft=true;
					oneFacingForward=false;
					oneFacingRight=false;
				
				}
			
				if(Input.GetKey(KeyCode.RightArrow) || movePlayer1Right)
				{
					player.transform.Rotate(0,90,0);
					oneFacingLeft=false;
					oneFacingForward=false;
					oneFacingRight=true;	
				}
				
				
				
			}
			
		
			if(oneFacingLeft)
			{
				if(Input.GetKey(KeyCode.UpArrow) || sendBombPlayer1)
				{				
					player.transform.Rotate(0,90,0);
					oneFacingLeft=false;
					oneFacingForward=true;
					oneFacingRight=false;
										
					if(insideCollider){
									
						changeSwitch(collision);
					}
				
				}
			
				if(Input.GetKey(KeyCode.RightArrow) || movePlayer1Right)
				{
					player.transform.Rotate(0,180,0);
					oneFacingLeft=false;
					oneFacingForward=false;
					oneFacingRight=true;	
				}
			}
				if(oneFacingRight)
				{
				if(Input.GetKey(KeyCode.UpArrow) || sendBombPlayer1)
					{				
					player.transform.Rotate(0,-90,0);
					oneFacingLeft=false;
					oneFacingForward=true;
					oneFacingRight=false;
					
					if(insideCollider){
												
					changeSwitch(collision);
				}
				
					}
			
				if(Input.GetKey(KeyCode.LeftArrow) || movePlayer1Left)
					{
					player.transform.Rotate(0,-180,0);	
					oneFacingLeft=true;
					oneFacingForward=false;
					oneFacingRight=false;	
					}
				}
				
				//Moves the Character
				if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || movePlayer1Left || movePlayer1Right) && !oneFacingForward)
				{
					player.transform.Translate(Vector3.forward * Time.smoothDeltaTime*moveSpeed);
					animation.Play("run");
				}
				else
				{
					animation.Play("idle");
				}
		}
		
		if(player.tag=="Player2")
		{
			//rotates the player
			if(twoFacingForward)
			{
				if(Input.GetKey(KeyCode.A) || movePlayer2Left)
				{				
					player.transform.Rotate(0,90,0);
					twoFacingLeft=true;
					twoFacingForward=false;
					twoFacingRight=false;
				
				}
			
				if(Input.GetKey(KeyCode.D) || movePlayer2Right)
				{
					player.transform.Rotate(0,-90,0);
					twoFacingLeft=false;
					twoFacingForward=false;
					twoFacingRight=true;	
				}
			}
			
		
			if(twoFacingLeft)
			{
				if(Input.GetKey(KeyCode.S) || sendBombPlayer2)
				{				
					player.transform.Rotate(0,-90,0);
					twoFacingLeft=false;
					twoFacingForward=true;
					twoFacingRight=false;
					
					if(insideCollider){
						
						changeSwitch(collision);
					}
				
				}
			
				if(Input.GetKey(KeyCode.D) || movePlayer2Right)
				{
					player.transform.Rotate(0,-180,0);
					twoFacingLeft=false;
					twoFacingForward=false;
					twoFacingRight=true;	
				}
			}
				if(twoFacingRight)
				{
				if(Input.GetKey(KeyCode.S) || sendBombPlayer2)
					{				
					player.transform.Rotate(0,90,0);
					twoFacingLeft=false;
					twoFacingForward=true;
					twoFacingRight=false;
					
					if(insideCollider){
												

						changeSwitch(collision);
					}
				
					}
			
				if(Input.GetKey(KeyCode.A) || movePlayer2Left)
					{
					player.transform.Rotate(0,180,0);	
					twoFacingLeft=true;
					twoFacingForward=false;
					twoFacingRight=false;	
					}
				}
				
				//Moves the Character
				if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || movePlayer2Left || movePlayer2Right) && !twoFacingForward)
				{
					player.transform.Translate(Vector3.forward * Time.smoothDeltaTime*moveSpeed);
					animation.Play("run");
				}
				else
				{
					animation.Play("idle");
				}
			}
		}
		else{
			moveSpeed = 0;
			animation.Play("idle");
			Time.timeScale = 0;
		}
	}
	
	public void Player1SendBomob(){
		sendBombPlayer1 = true;
		movePlayer1Left = false;
		movePlayer1Right = false;
	}
	
	public void MovePlayer1Right(){
		movePlayer1Left = false;
		sendBombPlayer1 = false;
		movePlayer1Right = true;
	}
	
	public void MovePlayer1Left(){
		movePlayer1Right = false;
		sendBombPlayer1 = false;
		movePlayer1Left = true;
	
	}
	
	public void Player2SendBomb(){
		movePlayer2Left = true;
		sendBombPlayer2 = false;
		movePlayer2Right = false;
	}
	
	public void MovePlayer2Right(){
		movePlayer2Left = false;
		sendBombPlayer2 = false;
		movePlayer2Right = true;
	}
	
	public void MovePlayer2Left(){
		movePlayer2Left = true;
		sendBombPlayer2 = false;
		movePlayer2Right = false;
	}
	
	public Vector3 GetPlayer1Position(){
		GameObject player1 = (GameObject) GameObject.FindGameObjectWithTag("Player1");
		return player1.transform.position;
	}
	
	public Vector3 GetPlayer2Position(){
		GameObject player2 = (GameObject) GameObject.FindGameObjectWithTag("Player2");
		return player2.transform.position;
	}
	
	public Vector3 GetBombPosition(string bombName){
		GameObject bomb = (GameObject) GameObject.FindGameObjectWithTag(bombName);
		return bomb.transform.position;
	}
	
	void changeSwitch(Collider other){
		
		if(other.tag=="Player1Switch1") 
		{			
				GameControl.player1switch1On=true;
			
				if(GameControl.player2switch1On)
				{
					GameControl.player2switch1On=false; 
				}
		
		}
		if(other.tag=="Player1Switch2")
		{
			
				 
				GameControl.player1switch2On=true;
			
				if(GameControl.player2switch2On)
				{
					GameControl.player2switch2On=false; 
				}
			
		}
		if(other.tag=="Player1Switch3")
		{
			
				GameControl.player1switch3On=true;
			
				if(GameControl.player2switch3On)
				{
					GameControl.player2switch3On=false; 
				}
			
		}
		if(other.tag=="Player1Switch4")
		{
			
				GameControl.player1switch4On=true;
			
				if(GameControl.player2switch4On)
				{
					GameControl.player2switch4On=false; 
				}
			
		}
		if(other.tag=="Player1Switch5")
		{
			
				GameControl.player1switch5On=true;
			
				if(GameControl.player2switch5On)
				{
					GameControl.player2switch5On=false; 
				}
			
		}
		if(other.tag=="Player1Switch6")
		{
			
				GameControl.player1switch6On=true;
			
				if(GameControl.player2switch6On)
				{
					GameControl.player2switch6On=false; 
				}
			
		}
		if(other.tag=="Player1Switch7")
		{
			
				GameControl.player1switch7On=true;
			
				if(GameControl.player2switch7On)
				{
					GameControl.player2switch7On=false; 
				}
			
		}
		if(other.tag=="Player1Switch8")
		{
			
				GameControl.player1switch8On=true;
			
				if(GameControl.player2switch8On)
				{
					GameControl.player2switch8On=false; 
				}
			
		}
		if(other.tag=="Player2Switch1")
		{
			
				GameControl.player2switch1On=true;
			
				if(GameControl.player1switch1On)
				{
					GameControl.player1switch1On=false; 
				}
			
		}
		if(other.tag=="Player2Switch2")
		{
			
				GameControl.player2switch2On=true;
			
				if(GameControl.player1switch2On)
				{
					GameControl.player1switch2On=false; 
				}
			
		}
		if(other.tag=="Player2Switch3")
		{
			
				GameControl.player2switch3On=true;
			
				if(GameControl.player1switch3On)
				{
					GameControl.player1switch3On=false; 
				}
			
		}
		if(other.tag=="Player2Switch4")
		{
			
				GameControl.player2switch4On=true;
			
				if(GameControl.player1switch4On)
				{
					GameControl.player1switch4On=false; 
				}
			
		}
		if(other.tag=="Player2Switch5")
		{
			
				GameControl.player2switch5On=true;
			
				if(GameControl.player1switch5On)
				{
					GameControl.player1switch5On=false; 
				}
			
		}
		if(other.tag=="Player2Switch6")
		{
			
				GameControl.player2switch6On=true;
			
				if(GameControl.player1switch6On)
				{
					GameControl.player1switch6On=false; 
				}
			
		}
		if(other.tag=="Player2Switch7")
		{
			
				GameControl.player2switch7On=true;
			
				if(GameControl.player1switch7On)
				{
					GameControl.player1switch7On=false; 
				}
			
		}
		if(other.tag=="Player2Switch8")
		{
			
				GameControl.player2switch8On=true;
			
				if(GameControl.player1switch8On)
				{
					GameControl.player1switch8On=false; 
				}
			
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		collision = other;
		insideCollider = true;		
		
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == collision.tag)
			insideCollider = false;
		
	}
}
