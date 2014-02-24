using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectChecker : MonoBehaviour {

    bool kill = false;

    MouseClick mouseClick;

    public Texture goalBar;
    public Texture goalBarBoarder;

    public AudioClip[] sound;

    float percentToGoal;

    float moves;

	// Use this for initialization
	void Start ()
    {
        mouseClick = this.GetComponent<MouseClick>();
	}
	
	// Update is called once per frame
	void Update () {
        percentToGoal = moves / 200f;
        if (percentToGoal >= 1f)
        {
			// load next level
			LoadingScene loadingSceneScript = GameObject.Find("EntireGameController").GetComponent("LoadingScene") as LoadingScene;
			
			loadingSceneScript.NextLevel();
			
			Application.LoadLevel(1);
        }
        for (float x = -3.6f; x >= -14.8f; x -= .8f)
        {
            string name = "";
            List<GameObject> toKill = new List<GameObject>();
            for (float y = -2.8f; y >= -10.8f; y -= .8f)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(x,y), Vector2.zero, .4f, 1 << LayerMask.NameToLayer("Food"));
                if (hit.collider != null)
                {
                    if (name.Equals(""))
                    {
                        name = hit.collider.gameObject.name;
                        toKill.Add(hit.collider.gameObject);
                    }
                    else
                    {
                        if (name.Equals(hit.collider.gameObject.name))
                        {
                            toKill.Add(hit.collider.gameObject);
                        }
                        else
                        {
                            if (toKill.Count >= 3)
                            {
                                foreach (GameObject gameObject in toKill)
                                {
                                    Destroy(gameObject);
                                }
                                audio.clip = sound[0];
                                audio.Play();
                                moves++;
                                mouseClick.unflip = false;
                            }
                            name = hit.collider.gameObject.name;
                            toKill.Clear();
                            toKill.Add(hit.collider.gameObject);
                        }
                    }
                }
                else
                {
                    if (toKill.Count >= 3)
                    {
                        foreach (GameObject gameObject in toKill)
                        {

                            Destroy(gameObject);
                        }
                        audio.clip = sound[0];
                        audio.Play();
                        moves++;
                        mouseClick.unflip = false;
                    }
                    name = "";
                    toKill.Clear();
                }
            }
            if (toKill.Count >= 3)
            {
                foreach (GameObject gameObject in toKill)
                {

                    Destroy(gameObject);
                }
                audio.clip = sound[0];
                audio.Play();
                moves++;
                mouseClick.unflip = false;
            }
        }

        for (float y = -2.8f; y >= -10.8f; y -= .8f)
        {
            string name = "";
            List<GameObject> toKill = new List<GameObject>();
            for (float x = -3.6f; x >= -14.8f; x -= .8f)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(x, y), Vector2.zero, .4f, 1 << LayerMask.NameToLayer("Food"));
                if (hit.collider != null)
                {
                    if (name.Equals(""))
                    {
                        name = hit.collider.gameObject.name;
                        toKill.Add(hit.collider.gameObject);
                    }
                    else
                    {
                        if (name.Equals(hit.collider.gameObject.name))
                        {
                            toKill.Add(hit.collider.gameObject);
                        }
                        else
                        {
                            if (toKill.Count >= 3)
                            {
                                foreach (GameObject gameObject in toKill)
                                {

                                    Destroy(gameObject);
                                }
                                audio.clip = sound[0];
                                audio.Play();
                                moves++;
                                mouseClick.unflip = false;
                            }
                            name = hit.collider.gameObject.name;
                            toKill.Clear();
                            toKill.Add(hit.collider.gameObject);
                        }
                    }
                }
                else
                {
                    if (toKill.Count >= 3)
                    {
                        foreach (GameObject gameObject in toKill)
                        {

                            Destroy(gameObject);
                        }
                        audio.clip = sound[0];
                        audio.Play();
                        moves++;
                        mouseClick.unflip = false;
                    }
                    name.Equals("");
                    toKill.Clear();
                }
            }
            if (toKill.Count >= 3)
            {
                foreach (GameObject gameObject in toKill)
                {

                    Destroy(gameObject);
                }
                audio.clip = sound[0];
                audio.Play();
                moves++;
                mouseClick.unflip = false;
            }
        }
	}
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(120, 550, 700, 40), goalBarBoarder);
        GUI.DrawTexture(new Rect(120, 550, 700 * percentToGoal, 40), goalBar);
    }
}
