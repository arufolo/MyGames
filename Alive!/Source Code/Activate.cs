using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {
	public static bool activate = false;
	public GameObject gun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(activate)
		{
			ActivateGun();
			activate = false;
		}
	
	}
	void ActivateGun(){
		gun.SetActive(true);
	}
}