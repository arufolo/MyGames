using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	bool FullAuto = false;
	public Rigidbody Bullet;
	public Transform Spawn;
	public float Bulletspeed = 2000.0f;
	public float ReloadTime = 2.0f;
	public static int AmmoLeft = 0;
	public static int AmmoInMag = 30;
	public int clips = 2;
	public static int totalBullets = 0;
	private bool CanFire = true;
	public float FireRate = 0.1f;



void Start () {
	AmmoLeft = AmmoInMag;
	totalBullets = clips*AmmoInMag;
	totalBullets -= AmmoInMag;
		HUD.hasGun = true;
}

void Update () {
	if(FullAuto){
		if(Input.GetMouseButtonDown(0)){
			if(AmmoLeft > 0){
				BroadcastMessage("FireAnim");
				StartCoroutine(Fire());
			}
		}
	}
	else{
		if(Input.GetMouseButton(0)){
			if(AmmoLeft > 0){
				BroadcastMessage("FireAnim");
				StartCoroutine(Fire());
			}
		}
	}
	if(Input.GetKeyDown(KeyCode.R) && AmmoLeft < AmmoInMag && totalBullets > 0){
		StartCoroutine(Reload());
		}

}
IEnumerator Fire (){
	if(CanFire){
		Rigidbody bullet1 = (Rigidbody)Instantiate(Bullet, Spawn.position, Spawn.rotation);
		bullet1.AddForce(transform.forward * Bulletspeed);
		AmmoLeft-=1;
		audio.Play();
		CanFire = false;
		yield return new WaitForSeconds(FireRate);
		CanFire = true;
		}
}
IEnumerator Reload (){
if(totalBullets > 0)
{
	CanFire = false;
	BroadcastMessage("ReloadAnim");
	BroadcastMessage("PlayReloadSound");
	yield return new WaitForSeconds(ReloadTime);
	var neededAmmo = AmmoInMag - AmmoLeft;
	if(totalBullets >= neededAmmo)
	{
		totalBullets -= neededAmmo;
		AmmoLeft = AmmoInMag;
	}
	else
	{
		AmmoLeft += totalBullets;
		totalBullets = 0;
	}
	CanFire = true;
	}
}
}
