using UnityEngine;
using System.Collections;

public class EndCutScene : MonoBehaviour {
	public string animation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameObject.animation.IsPlaying(animation))
		{
			Global.level = "Toronto";
			Application.LoadLevel("Load");
		}
	}
}
