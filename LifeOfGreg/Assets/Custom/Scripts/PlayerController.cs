using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float force;

	public GameObject bullet;
	public GameObject bulletPosition;
	public GameObject shell;
	private bool kickBack;
	private int count;
	public int countMax;
	public float bulletForce;
	public float bulletKickBack;
	public AudioClip getItemSound;
	
	public GameObject barrelTrans;

	public float distance;

	private Stack bullets;

	public int maxVel;


	// Use this for initialization
	void Start () {
		kickBack = true;
		count = 0;
		bullets = new Stack();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.W)){
			this.rigidbody.AddForce(transform.forward * force);

		}

		if(Input.GetKey(KeyCode.A)){
			this.rigidbody.AddForce(-transform.right * force);
			
		}

		if(Input.GetKey(KeyCode.S)){
			this.rigidbody.AddForce(-transform.up * force);
			
		}

		if(Input.GetKey(KeyCode.D)){
			this.rigidbody.AddForce(transform.right * force);
			
		}

		if(Input.GetKey(KeyCode.Space)){
			this.rigidbody.AddForce(transform.up * force);
			
		}

		if(Input.GetKey(KeyCode.Mouse0) && kickBack){

			audio.clip = getItemSound;
			audio.Play();
			
			GameObject newBullet = (GameObject) Instantiate(bullet, bulletPosition.gameObject.transform.position, bulletPosition.gameObject.transform.rotation);

			Vector3 direction =  bulletPosition.transform.position - barrelTrans.transform.position;
			direction.Normalize();

			newBullet.gameObject.rigidbody.AddForce(direction * bulletForce);

			bullets.Push(newBullet);

			this.rigidbody.AddForce(-transform.forward * bulletKickBack);
			kickBack = false;
		}

		if (!kickBack) {
			count += 1;

			if(count > countMax){
				kickBack = true;
				count = 0;
			}
		}

		if (bullets.Count > 0) {
			GameObject checkBullet = (GameObject) bullets.Peek();

			float checkDistance = Vector3.Distance(checkBullet.transform.position, this.transform.position);

			if(checkDistance > distance){
				GameObject destroyBullet = (GameObject)bullets.Pop();
				GameObject.Destroy(destroyBullet);
			}
		}

		this.rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVel);
	}
}
