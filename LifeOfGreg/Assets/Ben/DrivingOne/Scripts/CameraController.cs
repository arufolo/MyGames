using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject cameraTarget; // object to look at or follow

    public float smoothTime = 0.1f;    // time for dampen
    public Vector2 velocity; // speed of camera movement

    private Transform thisTransform; // camera Transform

    Vector3 position;
    float scale;

   // bool runOnce = true;

    // Use this for initialization
    void Start()
    {
        //scale = (float)Screen.width / 1920;
        //this.camera.orthographicSize = 5f + scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTarget != null)
        {
            thisTransform = transform;

            thisTransform.position = new Vector3(thisTransform.position.x, Mathf.SmoothDamp(thisTransform.position.y, cameraTarget.transform.position.y, ref velocity.y, smoothTime), thisTransform.position.z);

            position = new Vector3(transform.position.x, transform.position.y, 20);
        }
    }
}