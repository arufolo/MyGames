﻿using UnityEngine;
using System.Collections;

public class LandZone : MonoBehaviour {

	public static bool landed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {

		if(other.tag=="Chair")
		landed = true;
		
	}
	
	void OnTriggerExit(Collider other){

		if(other.tag=="Chair")
		landed = false;
		
	}
}
