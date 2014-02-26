using UnityEngine;
using System.Collections;


public class FlashLightPickUp : MonoBehaviour {
	
	public bool flashlightTriggered= false;
	public GameObject FlashLight;

	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(!audio.isPlaying)
		audio.Play();
		
		
		
		
		FlashLight.SetActive(true);
		
		if(!audio.isPlaying)
		Destroy(gameObject);
		
	}
		
		
}
