using UnityEngine;
using System.Collections;

public class CameraFollowChair : MonoBehaviour {

	public GameObject chair;
	float defaultCameraXdistance;
	float defaultCameraZdistance;
	float defaultCameraYdistance;
	float newCameraXDistance;
	float newCameraZDistance; 
	float newCameraYDistance;
	 

	// Use this for initialization
	void Start () {

		defaultCameraXdistance = chair.transform.position.x - this.gameObject.transform.position.x;
		defaultCameraZdistance = chair.transform.position.z - this.gameObject.transform.position.z;
		defaultCameraYdistance = chair.transform.position.y - this.gameObject.transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {

		newCameraXDistance = chair.transform.position.x - defaultCameraXdistance;
		newCameraZDistance = chair.transform.position.z - defaultCameraZdistance;
		newCameraYDistance = chair.transform.position.y - defaultCameraYdistance;

		this.gameObject.transform.position = new Vector3 (newCameraXDistance, newCameraYDistance, newCameraZDistance);
	
	}
}
