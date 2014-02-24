using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {
	
	public static float countdown = 5; 
	public static float score = 0;

	public AudioClip[] beep;

	// Use this for initialization
	void Start () {

		countdown = 5; 	
	}
	
	// Update is called once per frame
	void Update () {

		countdown -= Time.deltaTime;

		if (countdown > 4.9 && countdown < 5) 
		{
			if (!audio.isPlaying) 
			{
				audio.clip = beep[0];
				audio.Play ();
			}
		}
		if (countdown > 3.8 && countdown < 4.1) 
		{
			if (!audio.isPlaying) 
			{
				audio.clip = beep[0];
				audio.Play ();
			}
				
		}
		if (countdown > 2.8 && countdown < 3.1) 
		{
			if (!audio.isPlaying) 
			{
				audio.clip = beep[0];
				audio.Play ();
			}
			
		}
		if (countdown > 1.8 && countdown < 2.1) 
		{
			if (!audio.isPlaying) 
			{
				audio.clip = beep[0];
				audio.Play ();
			}
			
		}
		if (countdown > 0.8 && countdown < 1.1) 
		{
			if (!audio.isPlaying) 
			{
				audio.clip = beep[0];
				audio.Play ();
			}
			
		}
		if (countdown > -0.8 && countdown < .1) 
		{
			if (!audio.isPlaying) 
			{
				ChairController.controlsUnlocked = true;
				audio.clip = beep[1];
				audio.Play ();
			}

		}

		if (Mathf.Round (countdown) != -1)
						guiText.text = "" + Mathf.Round (countdown);
				else if (!audio.isPlaying)
						Destroy (this.gameObject);


		}
	
}
