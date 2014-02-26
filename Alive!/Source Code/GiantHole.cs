using UnityEngine;
using System.Collections;

public class GiantHole : MonoBehaviour {
	
	int timesPlayed=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(timesPlayed==0)
		audio.Play();
		
		timesPlayed++;
	}
}
