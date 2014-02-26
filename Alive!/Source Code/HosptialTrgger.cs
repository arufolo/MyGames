using UnityEngine;
using System.Collections;

public class HosptialTrgger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(HospitalEnter.hospitalEnter)
		{
			Global.level = "TheHospital";
			Application.LoadLevel("Load");
		}
	}
}
