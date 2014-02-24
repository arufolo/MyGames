using UnityEngine;
using System.Collections;

public class LoadingScene : MonoBehaviour {

	public GameObject[] chapterObjects;
	public GameObject[] controlObjects;
	public GameObject title;
	public GameObject credit;

	public int chapterCount;
	public int controlCount;
	private int newCount;
	private bool nextLevel;
	private Vector3 position;

	private GameObject currenObject;
	private Quaternion rotation;

	private int slideCount;
	private bool runOnce;

	private int levelCount;
	private bool sameLevel;

	private bool runInstantiate;

	private bool beginning;
	private int beginningCount;
	public int beginningMax;

	private bool credits;
	private int creditsCount;
	public int creditsMax;
	private bool loaded = true;
	private bool restart = false;

	// Use this for initialization
	void Start () {
		nextLevel = false;

		levelCount = 2;

		currenObject = GameObject.FindGameObjectWithTag("Slide");

		position = currenObject.transform.position;

		rotation = currenObject.transform.rotation;



		runOnce = true;
		sameLevel = false;
		runInstantiate = false;
		beginning = true;
		creditsCount = 0;
		beginningCount = 0;
		credits = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (restart) {
			Application.LoadLevel(0);
			GameObject.Destroy(this.gameObject);
		}
		else{
			DontDestroyOnLoad (this.gameObject);
		}


		if (beginning) {



			if(credits){

				if(loaded){
					Instantiate(credit, position, rotation);
					 
					loaded = false;
				}

				creditsCount += 1;
				
				if(creditsCount > creditsMax){
					restart = true;
				}
			}

			else{
				beginningCount += 1;
				
				if(beginningCount > beginningMax){

					currenObject = GameObject.FindGameObjectWithTag("Slide");
					GameObject.Destroy(currenObject);
					Instantiate(chapterObjects[slideCount], position, rotation);
					beginning = false;
					beginningCount = 0;
					nextLevel = true;

				}
			}

		}

		if (runInstantiate && newCount > 1) {
			Instantiate(chapterObjects[slideCount], position, rotation);
			runInstantiate = false;
		}

		if (nextLevel) {
			newCount += 1;
			
			if (newCount > chapterCount) {

				if(runOnce){
					currenObject = GameObject.FindGameObjectWithTag("Slide");

					GameObject.Destroy(currenObject);


					Instantiate(controlObjects[slideCount], position, rotation);
					runOnce = false;
				}

				if (newCount > controlCount) {



					Application.LoadLevel(levelCount);

					newCount = 0;
					nextLevel = false;
					runOnce = true;
				}
			}	
		}

		if (sameLevel) {
			newCount += 1;
			
			if (newCount > chapterCount) {
				
				if(runOnce){
					currenObject = GameObject.FindGameObjectWithTag("Slide");
					
					GameObject.Destroy(currenObject);
					
					
					Instantiate(controlObjects[slideCount], position, rotation);
					runOnce = false;
				}
				
				if (newCount > controlCount) {
					
					
					
					Application.LoadLevel(levelCount);
					newCount = 0;
					nextLevel = false;
					runOnce = true;
					sameLevel = false;
				}
			}	
		}

	}

	public void SameLevel(){
		sameLevel = true;
		runInstantiate = true;
		print (levelCount);
	}

	public void NextLevel(){
		slideCount += 1;
		levelCount += 1;
		nextLevel = true;
		runInstantiate = true;
	}

	public void FirstLevel(){

		
		levelCount = 2;

		
		slideCount = 0;
		
		runOnce = true;
		sameLevel = false;
		runInstantiate = false;
		credits = true;
		beginning = true;
		loaded = true;
	}
	
}
