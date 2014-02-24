using UnityEngine;
using System.Collections;

public class FireDespawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        particleSystem.renderer.sortingLayerName = "Foreground";
	}
	
	// Update is called once per frame
	void Update () {
        particleSystem.renderer.sortingLayerName = "Foreground";
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "waterBubble(Clone)")
        {
            Destroy(this.gameObject);
        }
    }
}
