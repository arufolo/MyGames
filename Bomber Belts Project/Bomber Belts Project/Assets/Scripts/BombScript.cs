using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
	
	public GameObject parent;
	BeltScript script;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		script = parent.GetComponent("BeltScript") as BeltScript;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "RedCollider"){
			Instantiate(explosion,transform.position,transform.rotation);
			audio.Play();
			script.ResetBomb("red");
			
		}
		
		if(other.gameObject.tag == "BlueCollider"){
			audio.Play();
			Instantiate(explosion,transform.position,transform.rotation);
			script.ResetBomb("blue");
			
		}
	}
}