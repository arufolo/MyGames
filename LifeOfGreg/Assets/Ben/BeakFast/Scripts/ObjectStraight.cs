using UnityEngine;
using System.Collections;

public class ObjectStraight : MonoBehaviour {
    float x;
	// Use this for initialization
	void Start () {
        x = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
	}
}
