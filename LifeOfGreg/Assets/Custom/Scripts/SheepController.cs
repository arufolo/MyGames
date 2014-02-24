using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

	private SleepWorldController script;
	public GameObject blood;
	private bool killed;
	private int hitCount;
	private int maxHit;
	private int bahNoise;
	private int bahCount;
	public AudioClip getItemSound;

	// Use this for initialization
	void Start () {
		script = GameObject.Find ("The Sun").GetComponent ("SleepWorldController") as SleepWorldController;
		killed = false;
		hitCount = 0;
		maxHit = 10;
		bahNoise = Random.Range (200, 500);
		bahCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (killed) {
			hitCount += 1;
			if(hitCount > maxHit){
				GameObject.Destroy(this.gameObject);		

			}
		}
		bahCount += 1;

		if (bahCount > bahNoise) {
			bahCount = 0;

			print ("bah");
			
			audio.clip = getItemSound;
			audio.Play();
		}
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Bullet" && !killed) {

	
			Vector3 position  = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z);
			Quaternion rotation = Quaternion.identity;
			GameObject newBlood = (GameObject)Instantiate(blood, position, rotation);
			newBlood.transform.parent = this.transform;
			killed = true;
			script.sheepKilled();
		}

		
	}


}
