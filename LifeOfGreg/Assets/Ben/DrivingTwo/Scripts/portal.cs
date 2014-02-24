using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour {

    public Transform point;
    public GameObject car;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Collider")
        {
            car.transform.position = point.position;
        }
    }
}
