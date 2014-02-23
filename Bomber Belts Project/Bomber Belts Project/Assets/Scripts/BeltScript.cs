using UnityEngine;
using System.Collections;

public class BeltScript : MonoBehaviour {
	
	public Material offMat;
	public Material redMat;
	public Material blueMat;
	Transform bombTransform;
	GameObject bomb;
	public float speed = 2f;
	public int debugNum = 0;
	Vector3 bombStart;

	// Use this for initialization
	void Start () {
		this.renderer.material = offMat;
		bombTransform = this.transform.FindChild("Bomb");
		bomb = bombTransform.gameObject;
		bombStart = bomb.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		bombTransform = this.transform.FindChild("Bomb");
		bomb = bombTransform.gameObject;
		SetBelt(debugNum);
	}
	
	void SetBelt(int num) {
		switch(num){
		case 0:
			this.renderer.material = offMat;
			break;
		case 1:
			this.renderer.material = redMat;
			bombTransform.Translate(-Vector3.right * Time.deltaTime * speed);
			break;
		case 2:
			this.renderer.material = blueMat;
			bombTransform.Translate(Vector3.right*Time.deltaTime* speed);
			break;
		}
	}
	
	public void ResetBomb(string color){
		if(color.Equals("red")){
			WorldScript.redLives--;
		}
		
		if(color.Equals("blue")){
			WorldScript.blueLives--;
		}
		bombTransform.position = bombStart;
		bombTransform.rotation = Quaternion.identity;
		debugNum = 0;
	}
}
