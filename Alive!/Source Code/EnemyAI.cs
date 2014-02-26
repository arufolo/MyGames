using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxdistance;
	int mindistance;
	int idledistance;
	public static bool isAttacking = false;
	public int enemyHealth = 100;
	bool isFuckingDead = false; 
	bool isIdling = false;
	bool isOnYou = false;
	bool seesYou = false; 
	
	
	
	private Transform myTransform;
	
	void Awake(){
		myTransform = transform;
	}


	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;
	
		maxdistance = 50;
		mindistance = 5;
		idledistance = 150;
	}
	

	void Update () {
		
		if(!isFuckingDead)
		{
			
		Debug.DrawLine(target.position, myTransform.position, Color.red); 
		

		
		
		if(Vector3.Distance(target.position, myTransform.position) < idledistance && Vector3.Distance(target.position, myTransform.position) > maxdistance)
		{
			animation.Play ("idle");
				if(seesYou)
				{
					seesYou = false; 
					isIdling = true;
				}
		}
		else if(Vector3.Distance(target.position, myTransform.position) < maxdistance && Vector3.Distance(target.position, myTransform.position) > mindistance){
		//Move towards target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			animation.Play("walk");
			BroadcastMessage("PlayWormWalks");
			if(!seesYou)
				{
					BroadcastMessage("PlaySeesYouSound");
					Debug.Log ("Working");
				seesYou = true;
				isAttacking = false;
				isIdling = false;
				isOnYou = false;
				}
		
			
		}
		else if(Vector3.Distance(target.position, myTransform.position) < mindistance)
		{
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
			animation.Play("attack");
			isAttacking = true;
			if(!audio.isPlaying)
			{
			audio.Play();
			}
				
			if(Bat.isSwinging)
				{
					enemyHealth-=20;
					Bat.isSwinging=false;
				}
				if(seesYou)
				{
					seesYou = false;
					isOnYou = true;
				}
		}
		
		if(enemyHealth<=0 && !isFuckingDead)
		{
			animation.Play("dead");
			
			BroadcastMessage("WormDeathSound");
			
			isFuckingDead = true;
			isAttacking = false; 
			
			
		}
		}
	
	
		
	}
		
}