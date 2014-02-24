using UnityEngine;
using System.Collections;

public class PingPongBallController : MonoBehaviour {

	private PingPong pingPongScript;

	public GameObject table;

	private int count;
	public int countMax;
	public int heightMax;

	private Vector3 downForce;

	public float dForce;

	// Use this for initialization
	void Start () {
		pingPongScript = GameObject.FindWithTag ("Player").GetComponent ("PingPong") as PingPong;
		count = 0;

		downForce = new Vector3 (0, -dForce, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (this.transform.position.y < table.transform.position.y) {
			pingPongScript.TryAgain();
		}

		if (this.transform.position.y < table.transform.position.y - 10) {
			GameObject.Destroy(this.gameObject);
		}

		if(this.transform.position.y > table.transform.position.y  && this.transform.position.y < table.transform.position.y + heightMax) {
			count += 1;
		}
		if (count > countMax) {
			pingPongScript.TryAgain();
			GameObject.Destroy(this.gameObject);
		}

		this.gameObject.rigidbody.AddForce (downForce);
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Cup") {

			string tempString = other.transform.parent.gameObject.ToString().Substring(0, 9);

			pingPongScript.CupHit(tempString);

			GameObject.Destroy(this.gameObject);

		}
	}


}
