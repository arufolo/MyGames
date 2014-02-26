using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour{

public GUIText Display;
//public GUIText Health;
//var CrossHair : GUITexture;
public static int health = 100;
int total = Gun.totalBullets;
float gameTime = 1.5f;
int ammo = Gun.AmmoInMag;
	public static bool hasGun = false;

void Start () {
	Display.text = "Ammo: \nHealth: ";
		health = 100;
	//Health.text = "Health: "+health;
}

void Update () {
	if(hasGun)
		Display.text = "Ammo: "+Gun.AmmoLeft+"-"+Gun.totalBullets+"\nHealth: "+health;
	else
		Display.text = "Health: "+health;
	if(health<=25 && !audio.isPlaying)
		audio.Play();
	if(health <= 0)
		{
		Application.LoadLevel("GameOver");
		EnemyAI.isAttacking = false;
		//EnemyAI.enemyHealth = 100; 
		}
	if(EnemyAI.isAttacking)
		{
			if(gameTime >= 1.5f)
			{
				Debug.Log("Called");
				health-=20;
				gameTime = 0;
			}
			else
			{
				gameTime += Time.deltaTime;
			}
		}
}

void OnTriggerEnter(Collider other) {
	if(other.tag == "Bullet" && health >0)
		{
			health-=5;
		}
}
}