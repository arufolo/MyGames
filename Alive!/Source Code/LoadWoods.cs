using UnityEngine;
using System.Collections;

public class LoadWoods : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
	Global.level = "TheBorder";
	Application.LoadLevel("Load");
}}
