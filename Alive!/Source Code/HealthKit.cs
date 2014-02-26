using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour {
	
	public int healthAmount = 20;
	bool isTriggered = false; 
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isTriggered && !audio.isPlaying)
		{
			Destroy(gameObject);
		}
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			int neededHealth = 100 - HUD.health;
			if(neededHealth >= healthAmount)
			{
				HUD.health+=healthAmount;
				audio.Play();
				isTriggered=true;
				
			}
			else if(neededHealth != 0)
			{
				HUD.health+=neededHealth;
				audio.Play ();
				isTriggered=true;				
				
			}
		}
	}

		
}
