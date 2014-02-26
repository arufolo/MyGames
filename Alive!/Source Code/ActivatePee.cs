using UnityEngine;
using System.Collections;

public class ActivatePee : MonoBehaviour {

	// Use this for initialization
	bool peeTriggered= false;
	public GameObject Piss;
	public GameObject light;
	int timesPeed=0;

	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!audio.isPlaying)
		{
			Piss.SetActive(false);
		}
		
	
	}
	
	void OnTriggerEnter(Collider other)
	{
	
		Piss.SetActive(true);
		light.SetActive(false);
		if(!audio.isPlaying)
		{
		audio.Play();
		peeTriggered = true;
		
		}
		
	}
	
	void OnTriggerExit(Collider other)
	{
	
		audio.Stop();
		Piss.SetActive(false);
		light.SetActive(true);
		
	}
	
}
