using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour {


	public static bool won = false;
	
	// Use this for initialization
	void Start () {

		won = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	
	void OnTriggerEnter(Collider other) {

		if (other.tag == "Chair") 
		{
			ChairReset.win = true;
			won = true;
		}
	}

}
