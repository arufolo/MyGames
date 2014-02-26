using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	int percent = 0;
	public GUIText progress;
	AsyncOperation async;

	// Use this for initialization
	void Start () {
		Application.LoadLevel(Global.level);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
