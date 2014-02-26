using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
	
	bool doorIsOpen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(!doorIsOpen)
		{
			audio.Play ();
			gameObject.animation.Play();
			doorIsOpen = true;
			
		}
	}
	
}
