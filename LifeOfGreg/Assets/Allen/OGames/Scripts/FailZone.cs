using UnityEngine;
using System.Collections;

public class FailZone : MonoBehaviour {

	public static bool failed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {

		if (other.tag == "Chair") {
						ChairReset.lose = true;
						failed = true;
				}
		
	}
	
	void OnTriggerExit(Collider other){

		if(other.tag=="Chair")
		failed = false;
		
	}
}
