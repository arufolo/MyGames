using UnityEngine;
using System.Collections;

public class ChairScore : MonoBehaviour {

	public static float totalScore = 0;
	private float rotationScore = 0;
	private float heightScore = 0;
	private float distanceScore = 0; 

	float height;
	float maxHeightReached;

	float currentRotation;
	float previousWRotation = 0;
	float previousXRotation = 0;
	float previousYRotation = 0;
	float previousZRotation = 0;

	public GameObject chair;


	// Use this for initialization
	void Start () {

		totalScore = 0;
		rotationScore = 0;
		heightScore = 0;
		distanceScore = 0;
		previousWRotation = 0;
		previousXRotation = 0;
		previousYRotation = 0;
		previousZRotation = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (InAirZone.isInAir) {
						if (chair.transform.position.y > maxHeightReached) {
								maxHeightReached = chair.transform.position.y;
								heightScore = maxHeightReached;
						}
			if(Mathf.Round(chair.transform.rotation.w) != previousWRotation)
			{
				previousWRotation = Mathf.Round(chair.transform.rotation.w);
				rotationScore++;
			}
			if(Mathf.Round(chair.transform.rotation.x) != previousXRotation)
			{
				previousXRotation = Mathf.Round(chair.transform.rotation.x);
				rotationScore++;
			}
			if(Mathf.Round(chair.transform.rotation.y) != previousYRotation)
			{
				previousYRotation = Mathf.Round(chair.transform.rotation.y);
				rotationScore++;
			}
			if(Mathf.Round(chair.transform.rotation.z) != previousZRotation)
			{
				previousZRotation = Mathf.Round(chair.transform.rotation.z);
				rotationScore++;
			}
				}						

		totalScore = rotationScore + heightScore + distanceScore;

		if(!WinZone.won)
		guiText.text = "Score: " + Mathf.Round (totalScore);
	
	}

	public void ResetScore()
	{
		totalScore = 0;
		rotationScore = 0;
		heightScore = 0;
		distanceScore = 0;
		previousWRotation = 0;
		previousXRotation = 0;
		previousYRotation = 0;
		previousZRotation = 0;
	}
}
