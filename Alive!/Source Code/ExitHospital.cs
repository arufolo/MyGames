using UnityEngine;
using System.Collections;

public class ExitHospital : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(Gate.key)
		{
			Global.level = "Toronto2";
			Application.LoadLevel("Load");
		}
	}
}
