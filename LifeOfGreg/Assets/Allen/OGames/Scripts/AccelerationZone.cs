using UnityEngine;
using System.Collections;

public class AccelerationZone : MonoBehaviour {

	public static bool canAccelerate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if(other.tag=="Chair")
		canAccelerate = true;

	}

	void OnTriggerExit(Collider other){

		if(other.tag=="Chair")
		canAccelerate = false;

	}

}
