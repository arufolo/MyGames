using UnityEngine;
using System.Collections;

public class HospitalEnter : MonoBehaviour {
	public static bool hospitalEnter = false;
	public GameObject Particles;
	
	// Use this for initialization
	void Start () {
		Particles.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(hospitalEnter)
			Particles.SetActive(true);
		
	}
	
}
