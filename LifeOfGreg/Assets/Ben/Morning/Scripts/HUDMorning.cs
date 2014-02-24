using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDMorning : MonoBehaviour {

    public Texture healthIcon;
    public Texture healthBarBoarder;
    public Texture healthBar;

	public AudioClip bubble; 

    List<Texture> collectedIcons = new List<Texture>();

    float health = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
        }
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, 100, 100), healthIcon);
        GUI.DrawTexture(new Rect(38, 100, 40, 300), healthBarBoarder);
        GUI.DrawTexture(new Rect(38, 100, 40, 300 * (health / 100)), healthBar);

        for (int i = 0; i < collectedIcons.Count; i++)
        {
            GUI.DrawTexture(new Rect(110 * i + 120, 10, 100, 100), collectedIcons[i]);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Fire (Mobile)")
        {
            this.rigidbody2D.AddForce(new Vector2(0,1) * 100f);
            health -= 5f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.name != "Log Out" && other.name != "DeathTrigger" )
        {
			audio.clip = bubble;
			audio.Play();

            collectedIcons.Add(other.transform.Find("icon").GetComponent<SpriteRenderer>().sprite.texture);
            Destroy(other.gameObject);
        }
        else
        {
			if (collectedIcons.Count >= 5 && other.name != "DeathTrigger")
            {
				// load next level
				LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
				
				loadingSceneScript.NextLevel();
				
				Application.LoadLevel(1);
            }
        }
    }
}
