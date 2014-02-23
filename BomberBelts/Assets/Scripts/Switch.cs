using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	
	public GameObject theSwitch;
	private bool onHasPlayed; 
	private bool offHasPlayed;
	
	// Use this for initialization
	void Start () {
		
		onHasPlayed = false;
		offHasPlayed = false; 
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameControl.player1switch1On)
		{
			if(theSwitch.tag == "Player1Switch1" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 
			}
		}
		if(GameControl.player1switch1On==false)
		{
			
			if(theSwitch.tag == "Player1Switch1" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}		
		if(GameControl.player2switch1On)
		{
			if(theSwitch.tag == "Player2Switch1" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch1On==false)
		{
			
			if(theSwitch.tag == "Player2Switch1" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
		if(GameControl.player1switch2On)
		{
			if(theSwitch.tag == "Player1Switch2" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player1switch2On==false)
		{
			
			if(theSwitch.tag == "Player1Switch2" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
		if(GameControl.player2switch2On)
		{
			if(theSwitch.tag == "Player2Switch2" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch2On==false)
		{
			
			if(theSwitch.tag == "Player2Switch2" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player1switch3On)
		{
			if(theSwitch.tag == "Player1Switch3" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player1switch3On==false)
		{
			
			if(theSwitch.tag == "Player1Switch3" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player2switch3On)
		{
			if(theSwitch.tag == "Player2Switch3" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch3On==false)
		{
			
			if(theSwitch.tag == "Player2Switch3" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player1switch4On)
		{
			if(theSwitch.tag == "Player1Switch4" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player1switch4On==false)
		{
			
			if(theSwitch.tag == "Player1Switch4" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player2switch4On)
		{
			if(theSwitch.tag == "Player2Switch4" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch4On==false)
		{
			
			if(theSwitch.tag == "Player2Switch4" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player1switch5On)
		{
			if(theSwitch.tag == "Player1Switch5" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player1switch5On==false)
		{
			
			if(theSwitch.tag == "Player1Switch5" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player2switch5On)
		{
			if(theSwitch.tag == "Player2Switch5" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch5On==false)
		{
			
			if(theSwitch.tag == "Player2Switch5" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player1switch6On)
		{
			if(theSwitch.tag == "Player1Switch6" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player1switch6On==false)
		{
			
			if(theSwitch.tag == "Player1Switch6" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player2switch6On)
		{
			if(theSwitch.tag == "Player2Switch6" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch6On==false)
		{
			
			if(theSwitch.tag == "Player2Switch6" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player1switch7On)
		{
			if(theSwitch.tag == "Player1Switch7" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player1switch7On==false)
		{
			
			if(theSwitch.tag == "Player1Switch7" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player2switch7On)
		{
			if(theSwitch.tag == "Player2Switch7" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch7On==false)
		{
			
			if(theSwitch.tag == "Player2Switch7" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player1switch8On)
		{
			if(theSwitch.tag == "Player1Switch8" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player1switch8On==false)
		{
			
			if(theSwitch.tag == "Player1Switch8" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
			if(GameControl.player2switch8On)
		{
			if(theSwitch.tag == "Player2Switch8" && onHasPlayed == false)
			{
				animation.Play("SwitchOn");
				onHasPlayed = true;		
				offHasPlayed = false; 				
				
			}
		}
		if(GameControl.player2switch8On==false)
		{
			
			if(theSwitch.tag == "Player2Switch8" && offHasPlayed == false && onHasPlayed == true)
			{
				animation.Play("SwitchOff");
				offHasPlayed = true;
				onHasPlayed  = false; 
			}
		}
	}
	

}
