using UnityEngine;
using System.Collections;

public class BoardGenerator : MonoBehaviour {

    public GameObject[] matchingObject;

	// Use this for initialization
	void Start () {
        for (float x = -3.6f; x >= -14.8f; x-=.8f)
        {
            for (float y = -2.8f; y >= -10.8f; y -= .8f)
            {
                int rand = Random.Range(0, matchingObject.Length);
                Instantiate(matchingObject[rand], new Vector2(x,y), Quaternion.identity);
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
        float y = -2.8f;
        for (float x = -3.6f; x >= -14.8f; x -= .8f)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(x, y), Vector2.zero, 20f, 1 << LayerMask.NameToLayer("Food"));
            if (hit.collider == null)
            {
                int rand = Random.Range(0, matchingObject.Length);
                Instantiate(matchingObject[rand], new Vector2(x, y), Quaternion.identity);
            }
        }
	}
}
