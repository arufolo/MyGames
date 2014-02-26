using UnityEngine;
using System.Collections;

public class GunPickUp : MonoBehaviour {

	bool triggered = false;
	public GameObject Weapon;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(triggered && !audio.isPlaying)
		{
			Destroy(gameObject);
		}
	
	}
	void OnTriggerEnter(Collider other) {
		audio.Play();
		triggered = true;
		Weapon.SetActive(true);
	}
}
