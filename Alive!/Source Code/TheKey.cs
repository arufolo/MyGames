using UnityEngine;
using System.Collections;

public class TheKey : MonoBehaviour {
	
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
		
			Gate.key=true;
			audio.Play();
			triggered = true;
			BroadcastMessage("PlayKeyPickUp");
			
			
			
			}
}
