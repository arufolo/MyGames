using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	
	public static string level = "CutScene";
	public static int health = 100;
	public static int numSoldiers = 0;
	public static int soldiersKilled = 0;

	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void Reset () {
		health = 100;
		numSoldiers = 0;
		soldiersKilled = 0;
	}
}
