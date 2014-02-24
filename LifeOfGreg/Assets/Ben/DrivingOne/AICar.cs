using UnityEngine;
using System.Collections;

public class AICar : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.rigidbody2D.velocity = (transform.right) * 4f;
	}
}

//