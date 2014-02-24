using UnityEngine;
using System.Collections;

public class ChairController : MonoBehaviour {

	public Rigidbody chair;
	public static GameObject playerChair;
	public int velocity; 
	public int rotateVelocity;
	public int flipVelocity; 
	public static bool controlsUnlocked = false;

	public Transform topPoint; 

	public Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);

	public static Vector3 defaultPosition = new Vector3(0,0,0); 


	// Use this for initialization
	void Start () {


		playerChair = GameObject.FindGameObjectWithTag ("Chair");
		controlsUnlocked = false;
		defaultPosition = playerChair.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (controlsUnlocked == true) {

						//Forward Velocity
						if (Input.GetKey (KeyCode.W) && AccelerationZone.canAccelerate) {
								chair.AddRelativeForce (Vector3.forward * velocity);

						}
						//Backward Velocity
						if (Input.GetKey (KeyCode.S) && !AccelerationZone.canAccelerate) {
								chair.AddRelativeForce (Vector3.right * velocity * -1);
			
						}

						//Left Rotation
						if (Input.GetKey (KeyCode.A)) {
								Quaternion deltaRotation = Quaternion.Euler (eulerAngleVelocity * -Time.deltaTime);
								rigidbody.MoveRotation (rigidbody.rotation * deltaRotation);
						}
						//Right Rotation
						if (Input.GetKey (KeyCode.D)) {
								Quaternion deltaRotation = Quaternion.Euler (eulerAngleVelocity * Time.deltaTime);
								rigidbody.MoveRotation (rigidbody.rotation * deltaRotation);	
						}

						//Left Barrell Roll
						if (Input.GetKey (KeyCode.LeftArrow)) {
								chair.rigidbody.AddForceAtPosition (-transform.right * rotateVelocity, topPoint.position);

						}
						//Right Barrell Roll
						if (Input.GetKey (KeyCode.RightArrow)) {
								chair.rigidbody.AddForceAtPosition (transform.right * rotateVelocity, topPoint.position);
			
						}
						//Backflip
						if (Input.GetKey (KeyCode.DownArrow)) {
								chair.rigidbody.AddForceAtPosition (-transform.forward * flipVelocity, topPoint.position);
			
						}
						//Backflip
						if (Input.GetKey (KeyCode.UpArrow)) {
								chair.rigidbody.AddForceAtPosition (transform.forward * flipVelocity, topPoint.position);
			
						}

				}
	}
}
