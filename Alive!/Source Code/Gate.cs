using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	public static bool key = false;
	string GateOpen = "GateOpen";
	GUIText display;
	int keyRecording = 1;
	bool isGateOpen=false;
	
	
	// Use this for initialization
	void Start () {
		display.text = "Press Enter to start level 2";
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnTriggerEnter(Collider other) {
		
			if(key&&!isGateOpen)
			{
				audio.Play();
				gameObject.animation.Play();
				isGateOpen=true;
			}
			if(!key)
			{
				if(keyRecording==1)
				{
					BroadcastMessage("PlayKeyRecording");
					keyRecording++;
				}
				else if(keyRecording==2)
				{
					BroadcastMessage("PlayKeyRecording2");
					keyRecording++;
				}
				else if(keyRecording==3)
				{
					BroadcastMessage("PlayKeyRecording3");
					keyRecording++;
				}
				else
				{
					BroadcastMessage("PlayKeyRecording4");
					keyRecording=1;
				}
				
			
			}
		
			
			
		
		
    }
}
