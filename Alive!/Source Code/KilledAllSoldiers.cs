using UnityEngine;
using System.Collections;

public class KilledAllSoldiers : MonoBehaviour {
	public GameObject Particles;

	// Use this for initialization
	void Start () {
		Particles.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Global.soldiersKilled == Global.numSoldiers)
			Particles.SetActive(true);
		Debug.Log("Soldiers Left: "+Global.numSoldiers+" Soldiers Killed: "+Global.soldiersKilled);
	}
}
