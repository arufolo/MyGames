using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public static bool hasLadder = false;
	//string GateOpen = "GateOpen";
	GUIText display;
	int ladderRecording = 1;
	
	
	
	// Use this for initialization
	void Start () {
		display.text = "Press Enter to start level 2";
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnTriggerEnter(Collider other) {
		
		if(other.tag == "Player")
		{
		
			
			if(hasLadder)
			{
				//audio.Play();
				//gameObject.animation.Play();
				if(HUD.hasGun)
				{
					Global.level = "TheBorder";
					Application.LoadLevel("Load");
				}
			
			}
			else
			{
				if(ladderRecording==1)
				{
					BroadcastMessage("PlayLadderRecording");
					ladderRecording++;
				}
				else if(ladderRecording==2)
				{
					BroadcastMessage("PlayLadderRecording2");
					ladderRecording++;
				}
				else if(ladderRecording==3)
				{
					BroadcastMessage("PlayLadderRecording3");
					ladderRecording++;
				}
				else if(ladderRecording==4)
				{
					BroadcastMessage("PlayLadderRecording4");
					ladderRecording++;
				}
				else if(ladderRecording==5)
				{
					BroadcastMessage("PlayLadderRecording5");
					ladderRecording++;
				}
				else
				{
					BroadcastMessage("PlayLadderRecording6");
					ladderRecording=1;
				}
				
			
			}
		}
		
			
			
		
		
    }
}
