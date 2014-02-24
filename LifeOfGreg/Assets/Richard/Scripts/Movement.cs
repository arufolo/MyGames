using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    float horizontal;
    float vertical;
    float speed = 70f;
    Animator anim;
	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(-vertical,0,horizontal);
        direction.Normalize();
        rigidbody.velocity = direction * speed;
        anim.SetFloat("velocity", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, Vector3.up);
	}
}
