using UnityEngine;
using System.Collections;

public class SniperAI : MonoBehaviour {
	public Rigidbody bullet;
	public Transform spawn;
	public float Bulletspeed;
	int ReloadTime = 5;
	static int AmmoLeft = 0;
	int AmmoInMag = 30;
	private bool CanFire = true;
	System.Random rnd = new System.Random();
	float FireRate = 0.5f;
	public GameObject character;
	float distanceToPlayer;
	public float radius = 15.0f;
	Vector3 forward = new Vector3(-1.0f, 0.0f, 0.0f);
	float rotationSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		AmmoLeft = AmmoInMag;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToPlayer = Vector3.Distance(this.transform.position, character.transform.position);
		if(distanceToPlayer<=radius)
		{
			//transform.LookAt(character.transform.position);
			Vector3 newRotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(character.transform.position - transform.position), rotationSpeed*Time.deltaTime).eulerAngles;
  			newRotation.x = 0;
  			newRotation.z = 0;
  			transform.rotation = Quaternion.Euler(newRotation);
			
			StartCoroutine(Fire ());
		
		}
	
	}
	IEnumerator Fire (){
		if(CanFire){
			FireRate = (float)rnd.Next(5,8);
			Rigidbody bullet1 = (Rigidbody)Instantiate(bullet, spawn.position, spawn.rotation);
			bullet1.AddForce(transform.forward * Bulletspeed);
			AmmoLeft-=1;
			audio.Play();
			CanFire = false;
			yield return new WaitForSeconds(FireRate);
			CanFire = true;
		}
		
	}
	IEnumerator Reload (){
		CanFire = false;
		//BroadcastMessage("ReloadAnim");
		yield return new WaitForSeconds(ReloadTime);
		AmmoLeft = AmmoInMag;
		CanFire = true;
	}
}
