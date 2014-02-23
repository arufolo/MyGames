using UnityEngine;
using System.Collections;

public class Bomb8 : MonoBehaviour {
	
	public GameObject bomb;
	public int bombSpeed; 
	public static int direction; 
	public int bombNumber;
	public static int switchNumber;
	public Vector3 spawnSpot;
	
	public GameObject explosion; 

	// Use this for initialization
	void Start () {
		
		direction = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(bombNumber == switchNumber )
			bomb.transform.Translate(Vector3.forward * Time.smoothDeltaTime*bombSpeed*direction);
	}
	
		void OnTriggerEnter(Collider other) {
		
		if(other.tag == "ScorePoint1")
		{
			GameControl.player1switch8On = false;
			Instantiate(explosion, bomb.transform.position, transform.rotation);
			audio.Play();
			ResetBomb();
			GameControl.player1score++;
			
			
		}
		if(other.tag == "ScorePoint2")
		{
			
			GameControl.player2switch8On = false; 
			Instantiate(explosion, bomb.transform.position, transform.rotation);
			audio.Play();
			ResetBomb();
			GameControl.player2score++;
			
		}
	}
	
		void ResetBomb() {
		
		direction = 0;
		bomb.transform.position = spawnSpot;
		
	}
}
