using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

	// Use this for initialization
	double delay = 2.0/6.0;
	public static bool isSwinging = false; 
	public Transform spawn;

void Start () {

}

void Update () {
		if(HUD.hasGun)
		{
			//GameObject bat = (GameObject)Instantiate(gameObject, spawn.position, spawn.rotation);
			Destroy(gameObject);
		}

if(Input.GetMouseButton(0)){
			
				BroadcastMessage("BatAnim");
				if(!audio.isPlaying) 
				{
				audio.Play();
				}
				if(EnemyAI.isAttacking && delay>=(2.0/6.0))
				{
				BroadcastMessage("BatHitSound");
				//EnemyAI.enemyHealth-=20;
				delay=0;
				isSwinging = true; 
				}
			

				}
		if(delay<(2.0/6.0))
		{
			delay+=Time.deltaTime;
			//isSwinging=false; 
		}
}
}
