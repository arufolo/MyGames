using UnityEngine;
using System.Collections;

public class Veggie : MonoBehaviour {

	GameObject Player; 
	public static bool veggieThrown; 
	GameObject veggie;
	float speed = .25f;
	public static bool isBurger = false;

	private bool beenThrown = false;
	//0 for right 1 for left
	int directionFacingWhenThrown=0;

	public float xForce = 10;
	public float yForce = 10;

	private BoxCollider2D boxCol;
	 

	// Use this for initialization
	void Start () {

		veggie = this.gameObject;
		Player = GameObject.FindGameObjectWithTag ("Player");
		audio.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector2.Distance (Player.transform.position, veggie.transform.position) > 25f) 
		{
				Destroy (this.gameObject);
		}


		if (veggieThrown) {

			veggie.transform.parent = null;
			if(PlayerControl.facingRight)
			{
				directionFacingWhenThrown = 0;
			}
			else
				directionFacingWhenThrown=1;

			beenThrown = true; 

			PlayerControl.hasVegetable = false;

			veggieThrown = false; 

				}

		if (beenThrown) {

			if(directionFacingWhenThrown == 0)
			{
				veggie.transform.Translate(Vector2.right*speed);
			}
			else
			{
				veggie.transform.Translate(Vector2.right*speed*-1);
			}
			veggie.transform.Translate(Vector2.up*speed*-1);



				}

	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Basket") 
		{
			if(Veggie.isBurger == true)
			{
				Score.score -=2;
			}
			boxCol = veggie.GetComponent<BoxCollider2D>();
			boxCol.collider2D.enabled = false;
		}
	}
	
}
