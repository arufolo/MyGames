using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

	public AudioClip[] crowd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (AccelerationZone.canAccelerate) 
		{
			audio.clip = crowd [0];
			if(!audio.isPlaying)
			audio.Play();
		}
		if (WinZone.won) 
		{
			audio.clip = crowd [1];
			if(!audio.isPlaying)
			audio.Play ();
		}
		if (FailZone.failed) 
		{
			audio.clip = crowd [2];
			if(!audio.isPlaying)
			audio.Play ();
		}
	
	}
	
}
