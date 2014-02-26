using UnityEngine;
using System.Collections;

public class AIFire : MonoBehaviour {
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
	public float radius = 20.0f;
	Vector3 forward = new Vector3(-1.0f, 0.0f, 0.0f);
	float rotationSpeed = 2.0f;
	public int health = 5;

	// Use this for initialization
	void Start () {
		AmmoLeft = AmmoInMag;
		Global.numSoldiers++;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToPlayer = Vector3.Distance(this.transform.position, character.transform.position);
		if(distanceToPlayer<=radius && health>0)
		{
			//transform.LookAt(character.transform.position);
			Vector3 newRotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(character.transform.position - transform.position), rotationSpeed*Time.deltaTime).eulerAngles;
  			newRotation.x = 0;
  			newRotation.z = 0;
  			transform.rotation = Quaternion.Euler(newRotation);
			StartCoroutine(Fire ());
		}
		if(health <= 0)
		{
			Global.soldiersKilled++;
			health = 1;
			Destroy (gameObject);
		}
	
	}
	IEnumerator Fire (){
		if(CanFire){
			FireRate = .1f * (float)rnd.Next(1,6);
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
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Bullet")
			health-=1;
	}
}
