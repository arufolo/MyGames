using UnityEngine;
using System.Collections;

public class TheLadder : MonoBehaviour {
	
	bool triggered = false;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(triggered && !audio.isPlaying)
		{
			
			Destroy(gameObject);
			
		}
	
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player")
		{
			Wall.hasLadder=true;
			audio.Play();
			triggered = true;
			BroadcastMessage("PlayKeyPickUp");
			
		}	
			
			}
}
