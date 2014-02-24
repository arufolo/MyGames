using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PingPong : MonoBehaviour {

	public GameObject pingPongBall;

	public GameObject backLeft;
	public GameObject backMiddle;
	public GameObject backRight;

	public GameObject midLeft;
	public GameObject midRight;

	public GameObject front;

	private Dictionary<string, GameObject> cups;


	public Texture target;

	private bool aiming;

	public float throwingBar;
	private float currentThowingBarLength;
	private float thowingBoarderBarLength;
	private float throwingPercent;
	private float maxBar;

	public Texture throwingBarTexture;
	public Texture throwingBoarderBarTexture;

	private GameObject currentBall;

	private Vector3 ballForce;

	private bool runOnce;

	private bool reduce;

	// Use this for initialization
	void Start () {
	
		cups = new Dictionary<string, GameObject> ();


		cups.Add (backLeft.gameObject.ToString().Substring(0, 9), backLeft);
		cups.Add (backMiddle.gameObject.ToString().Substring(0, 9), backMiddle);
		cups.Add (backRight.gameObject.ToString().Substring(0, 9), backRight);

		cups.Add (midLeft.gameObject.ToString().Substring(0, 9), midLeft);
		cups.Add (midRight.gameObject.ToString().Substring(0, 9), midRight);

		cups.Add (front.gameObject.ToString().Substring(0, 9), front);



		maxBar = Screen.width - (Screen.width / 20);

		throwingPercent = throwingBar / maxBar;

		currentThowingBarLength = throwingPercent * maxBar;

		thowingBoarderBarLength = maxBar;

		aiming = true;

		throwingBar = 0;

		runOnce = true;

		reduce = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (cups.Count < 1) {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;

			loadingSceneScript.NextLevel();

			Application.LoadLevel(1);
		}

		if (reduce) {

			if(throwingBar > 0){

				throwingBar -= 5;
			}
			else{
				reduce = false;
			}
		}

		if (aiming) {
	
			if(Input.GetKey(KeyCode.Mouse0) && throwingBar < maxBar - 10){
				throwingBar += 10;

			}

			if(Input.GetMouseButtonUp(0)) {
				aiming = false;

				reduce = true;

			}

		}


		else{
			if(runOnce){
			
			
				Vector3 position = new Vector3(this.transform.position.x, pingPongBall.transform.position.y, pingPongBall.transform.position.z);
				
				
				ballForce = new Vector3(0, throwingPercent, throwingPercent) * 7000;
				
				currentBall = (GameObject) Instantiate(pingPongBall, position, pingPongBall.transform.rotation);
				currentBall.transform.position = position;
				currentBall.transform.rigidbody.AddForce(ballForce);

				runOnce = false;

			}

		}

		throwingPercent = throwingBar / maxBar;
		currentThowingBarLength = throwingPercent * maxBar;

	}

	public void TryAgain(){
		
		aiming = true;
		
		throwingBar = 0;
		
		runOnce = true;
	}

	public void CupHit(string cupTag){

		GameObject temp;

		if (cups.TryGetValue (cupTag, out temp)) {
			cups.Remove (cupTag);
			
			GameObject.Destroy (temp.gameObject);
		}



		aiming = true;
		
		throwingBar = 0;
		
		runOnce = true;
	}


	void OnGUI(){

		if (aiming){
			Screen.showCursor = false;
			
			GUI.DrawTexture(new Rect(Screen.width /2 - 10, Screen.height / 2 - 10, 20, 20), target); 

			
		}

		GUI.DrawTexture(new Rect(10, 10, thowingBoarderBarLength, Screen.height / 20), throwingBoarderBarTexture); 
		
		GUI.DrawTexture(new Rect(10, 10, currentThowingBarLength, Screen.height / 20), throwingBarTexture); 

	}
	
}
