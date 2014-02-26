

function Start () {

}

function Update () {

if(Input.GetMouseButton(0)){
			
				BroadcastMessage("BatAnim");
				if(!audio.isPlaying) 
				{
				audio.Play();
				}
				
				BroadcastMessage("BatHitSound");
			}
			

}