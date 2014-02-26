#pragma strict
var Swing : String;
var BatWalk : String;
var isSwinging = false;

function Start () {

}

function Update () {
	if(Input.GetAxis("Vertical") || Input.GetAxis("Horizontal")){
		BatWalkAnim();
	}
}

function BatAnim (){
		
		gameObject.animation.Stop(BatWalk);
		gameObject.animation.Play(Swing);
		
		}
		
function BatWalkAnim(){

		if(!gameObject.animation.IsPlaying(Swing))
		{		
		gameObject.animation.Play(BatWalk);
		}
		}
	