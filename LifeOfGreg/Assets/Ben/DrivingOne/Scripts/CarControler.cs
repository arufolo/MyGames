using UnityEngine;
using System.Collections;

public class CarControler : MonoBehaviour {

    public Transform Front;

    float speed = 4f;

    float rotateClamp = 1f;

    public GameObject main;

    public AudioClip[] sounds;

    HUD hud;

	// Use this for initialization
	void Start () {
        hud = main.GetComponent<HUD>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 direction = Front.transform.position - this.transform.position;
        direction.Normalize();
        this.rigidbody2D.AddForceAtPosition(direction * speed, Front.transform.position);

        float input = Input.GetAxis("Horizontal");
        this.rigidbody2D.AddForceAtPosition(new Vector2(input * 10f, 0), Front.transform.position);

        if (this.rigidbody2D.angularVelocity > rotateClamp)
        {
            this.rigidbody2D.angularVelocity = rotateClamp;
        }
        if (this.rigidbody2D.angularVelocity < -rotateClamp)
        {
            this.rigidbody2D.angularVelocity = -rotateClamp;
        }
        if (input == 0f)
        {

            if (audio.clip != sounds[2])
                audio.clip = sounds[0];
            else
            {
                if (!audio.isPlaying)
                {
                    audio.clip = sounds[0];
                }
            }
            this.rigidbody2D.angularVelocity = 0f;
        }
        else
        {
            if (audio.clip != sounds[2])
                audio.clip = sounds[1];
            else
            {
                if (!audio.isPlaying)
                {
                    audio.clip = sounds[1];
                }
            }
        }

        if (!audio.isPlaying)
        {
            audio.Play();
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        audio.clip = sounds[2];
        audio.Play();
        hud.reduceHealth(10);
    }
}
