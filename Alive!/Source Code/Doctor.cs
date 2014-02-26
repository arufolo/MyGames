using UnityEngine;
using System.Collections;

public class Doctor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(!audio.isPlaying && !Gate.key)
		{
			audio.Play();
			HospitalEnter.hospitalEnter = true;
		}
	}
}
