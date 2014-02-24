using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

	public static bool onPlant;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			onPlant = true;

		}
		
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			onPlant = false;
		}
	}

}
