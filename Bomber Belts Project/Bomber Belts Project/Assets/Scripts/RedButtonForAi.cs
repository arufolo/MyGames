using UnityEngine;
using System.Collections;

public class RedButtonForAi : MonoBehaviour {
	public bool on = false;
	public GameObject player;
	public BeltScript beltScript;
	public RedCharacterActions redCharacter;
	int beltDirection;
	public bool here;
	public Material onMat;
	public Material offMat;
	
	
	// Use this for initialization
	void Start () {
		beltScript = transform.parent.GetComponent("BeltScript") as BeltScript;
		redCharacter = player.GetComponent("RedCharacterActions") as RedCharacterActions;
		beltDirection = beltScript.debugNum;
	
	}
	
	// Update is called once per frame
	void Update () {
		beltDirection = beltScript.debugNum;
		if(beltDirection == 1){
			on = true;
			this.renderer.material = onMat;
		}else{
			on = false;
			if(beltDirection != 0){
				this.renderer.material = offMat;
			}
		}
		
	
	}
	
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			here = true;
				
				
		}
				
	}
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			here = false;
		}
	}
	
	public void Push(){
		if(!on && here){
			Debug.Log("heyo");
			beltScript.debugNum = 1;
			redCharacter.canMove = false;
			redCharacter.animation.Play("PushButton");
			StartCoroutine(PushingWait());
		}
	}
	
	IEnumerator PushingWait() {
		yield return new WaitForSeconds(.5f);
		redCharacter.canMove = true;
	}
}
		

