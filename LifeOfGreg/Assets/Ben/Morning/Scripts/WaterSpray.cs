using UnityEngine;
using System.Collections;

public class WaterSpray : MonoBehaviour {

    public GameObject waterBubble;
    public Transform sprayPoint;

	public AudioClip water;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
			if(!audio.isPlaying){
				audio.clip = water;
				audio.Play();
			}




            GameObject gameObject = Instantiate(waterBubble, sprayPoint.position, Quaternion.identity) as GameObject;
            Vector2 direction = (Vector2)sprayPoint.position - (((Vector2)this.transform.position) - (Vector2)transform.forward);
            direction.Normalize();
            gameObject.rigidbody2D.AddForce(direction * 100f);
        }
		else{
			audio.Stop();
		}
	}
}
