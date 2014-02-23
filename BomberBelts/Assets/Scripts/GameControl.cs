using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	
	public static bool player1switch1On;
	public static bool player1switch2On;
	public static bool player1switch3On;
	public static bool player1switch4On;
	public static bool player1switch5On;
	public static bool player1switch6On;
	public static bool player1switch7On;
	public static bool player1switch8On;
	public static bool player2switch1On;
	public static bool player2switch2On;
	public static bool player2switch3On;
	public static bool player2switch4On;
	public static bool player2switch5On;
	public static bool player2switch6On;
	public static bool player2switch7On;
	public static bool player2switch8On;
	
	public static int player1score;
	public static int player2score;
	
	public static bool gameOver = false; 
	public static bool stop;
		
	
	// Use this for initialization
	void Start () {
		
	 player1switch1On = false;
	 player1switch2On = false;
	 player1switch3On= false;
	 player1switch4On= false;
	 player1switch5On= false;
	 player1switch6On= false;
	 player1switch7On= false;
	 player1switch8On= false;
	 player2switch1On= false;
	 player2switch2On= false;
	 player2switch3On= false;
	 player2switch4On= false;
	 player2switch5On= false;
	 player2switch6On= false;
	 player2switch7On= false;
	 player2switch8On= false;
		
		player1score = 0;
		player2score = 0;
		
		gameOver = false; 
		
		stop = false;
	
		
	
	}
	
	 void OnGUI() {
        GUILayout.Label("Player 1 Score: " +player1score);
		GUILayout.Label("Player 2 Score: " +player2score);
		
		if(player1score == 10 && gameOver == true)
		{
				GUILayout.Label("Player 1 Wins!");
				Application.Quit();
			stop = true;
		}
		if(player2score == 10 && gameOver == true)
		{
			  	GUILayout.Label("Player 2 Wins!");
				Application.Quit();
			stop = true;
		}
		
		
		
    }
	
	// Update is called once per frame
	void Update () {
		if(!stop){
		
		if(player1score == 10 || player2score == 10)
		{
			gameOver = true;
		}
		
		if(player1switch1On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb1.direction = 1;
			Bomb1.switchNumber = 1;
		}
		
		if(player1switch2On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb2.direction = 1;
			Bomb2.switchNumber = 2;

		}
		
		if(player1switch3On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb3.direction = 1;
			Bomb3.switchNumber = 3;
		}
		
		if(player1switch4On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb4.direction = 1;
			Bomb4.switchNumber = 4;
		}
		
		if(player1switch5On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb5.direction = 1;
			Bomb5.switchNumber = 5;
		}
		
		if(player1switch6On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb6.direction = 1;
			Bomb6.switchNumber = 6;
		}
		
		if(player1switch7On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb7.direction = 1;
			Bomb7.switchNumber = 7;
		}
		
		if(player1switch8On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb8.direction = 1;
			Bomb8.switchNumber = 8;
		}
		
		if(player2switch1On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb1.direction = -1;
			Bomb1.switchNumber = 1;
		}
		
		if(player2switch2On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb2.direction = -1;
			Bomb2.switchNumber = 2;
		}
		
		if(player2switch3On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb3.direction = -1;
			Bomb3.switchNumber = 3;
		}
		
		if(player2switch4On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb4.direction = -1;
			Bomb4.switchNumber = 4;
		}
		
		if(player2switch5On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb5.direction = -1;
			Bomb5.switchNumber = 5;
		}
		
		if(player2switch6On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb6.direction = -1;
			Bomb6.switchNumber = 6;
		}
		
		if(player2switch7On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb7.direction = -1;
			Bomb7.switchNumber = 7;
		}
		
		if(player2switch8On)
		{
			//BroadcastMessage("PlaySwitchOn1");
			Bomb8.direction = -1;
			Bomb8.switchNumber = 8;
		}
		}
	
	}
}
