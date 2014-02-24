using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Texture workIcon;
    public Texture homeIcon;
    public Texture healthIcon;

    public Texture travelBar;
    public Texture travelBarBoarder;

    public Texture healthBar;
    public Texture healthBarBoarder;

    public Transform player;

    float health = 100;

    float goalY = 500f;
    float playerStartY;
    float percentToGoal;

	// Use this for initialization
	void Start () {
        playerStartY = player.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        percentToGoal = (player.position.y - playerStartY) / goalY;

        if (health <= 0)
        {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.SameLevel();
			
			Application.LoadLevel(1);
        }
        if (percentToGoal >= 1)
        {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.NextLevel();
			
			Application.LoadLevel(1);
        }
	}


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(20, 500, 100, 100), homeIcon);
        GUI.DrawTexture(new Rect(840, 500, 100, 100), workIcon);

        GUI.DrawTexture(new Rect(120, 550, 700, 40), travelBarBoarder);
        GUI.DrawTexture(new Rect(120, 550, 700 * percentToGoal, 40), travelBar);

        GUI.DrawTexture(new Rect(10, 10, 100, 100), healthIcon);
        GUI.DrawTexture(new Rect(38, 100, 40, 300), healthBarBoarder);
        GUI.DrawTexture(new Rect(38, 100, 40, 300 * (health / 100)), healthBar);
    }

    public void reduceHealth(int amount)
    {
        health -= amount;
    }
}
