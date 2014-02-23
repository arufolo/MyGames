using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour {
	
	public Vector2 uvAnimationRate = new Vector2( 1f, 0.0f );
	Vector2 uvOffset = Vector2.zero;
	public Material redMat;
	public Material blueMat;
	public static int redLives = 7;
	public static int blueLives = 7;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		uvOffset += ( uvAnimationRate * Time.deltaTime * 0.4f);
		redMat.SetTextureOffset("_MainTex",-uvOffset);
		blueMat.SetTextureOffset("_MainTex",-uvOffset);
		
		switch(blueLives){
		case 7:
			break;
		case 6:
			Destroy(GameObject.Find("BHeart7"));
			break;
		case 5:
			Destroy(GameObject.Find("BHeart7"));
			Destroy(GameObject.Find("BHeart6"));
			break;
		case 4:
			Destroy(GameObject.Find("BHeart7"));
			Destroy(GameObject.Find("BHeart6"));
			Destroy(GameObject.Find("BHeart5"));
			break;
		case 3:
			Destroy(GameObject.Find("BHeart7"));
			Destroy(GameObject.Find("BHeart6"));
			Destroy(GameObject.Find("BHeart5"));
			Destroy(GameObject.Find("BHeart4"));
			break;
		case 2:
			Destroy(GameObject.Find("BHeart7"));
			Destroy(GameObject.Find("BHeart6"));
			Destroy(GameObject.Find("BHeart5"));
			Destroy(GameObject.Find("BHeart4"));
			Destroy(GameObject.Find("BHeart3"));
			break;
		case 1:
			Destroy(GameObject.Find("BHeart7"));
			Destroy(GameObject.Find("BHeart6"));
			Destroy(GameObject.Find("BHeart5"));
			Destroy(GameObject.Find("BHeart4"));
			Destroy(GameObject.Find("BHeart3"));
			Destroy(GameObject.Find("BHeart2"));
			break;
		case 0:
			Destroy(GameObject.Find("BHeart7"));
			Destroy(GameObject.Find("BHeart6"));
			Destroy(GameObject.Find("BHeart5"));
			Destroy(GameObject.Find("BHeart4"));
			Destroy(GameObject.Find("BHeart3"));
			Destroy(GameObject.Find("BHeart2"));
			Destroy(GameObject.Find("BHeart1"));
			GameObject.Find("Winner Display").guiText.text = "Red Player Wins!";
			Time.timeScale = 0.0f;  
			break;
		}
		
		switch(redLives){
		case 7:
			break;
		case 6:
			Destroy(GameObject.Find("RHeart7"));
			break;
		case 5:
			Destroy(GameObject.Find("RHeart7"));
			Destroy(GameObject.Find("RHeart6"));
			break;
		case 4:
			Destroy(GameObject.Find("RHeart7"));
			Destroy(GameObject.Find("RHeart6"));
			Destroy(GameObject.Find("RHeart5"));
			break;
		case 3:
			Destroy(GameObject.Find("RHeart7"));
			Destroy(GameObject.Find("RHeart6"));
			Destroy(GameObject.Find("RHeart5"));
			Destroy(GameObject.Find("RHeart4"));
			break;
		case 2:
			Destroy(GameObject.Find("RHeart7"));
			Destroy(GameObject.Find("RHeart6"));
			Destroy(GameObject.Find("RHeart5"));
			Destroy(GameObject.Find("RHeart4"));
			Destroy(GameObject.Find("RHeart3"));
			break;
		case 1:
			Destroy(GameObject.Find("RHeart7"));
			Destroy(GameObject.Find("RHeart6"));
			Destroy(GameObject.Find("RHeart5"));
			Destroy(GameObject.Find("RHeart4"));
			Destroy(GameObject.Find("RHeart3"));
			Destroy(GameObject.Find("RHeart2"));
			break;
		case 0:
			Destroy(GameObject.Find("RHeart7"));
			Destroy(GameObject.Find("RHeart6"));
			Destroy(GameObject.Find("RHeart5"));
			Destroy(GameObject.Find("RHeart4"));
			Destroy(GameObject.Find("RHeart3"));
			Destroy(GameObject.Find("RHeart2"));
			Destroy(GameObject.Find("RHeart1"));
			GameObject.Find("Winner Display").guiText.text = "Blue Player Wins!";
			Time.timeScale = 0.0f;  
			break;
		}
	
	}
}
