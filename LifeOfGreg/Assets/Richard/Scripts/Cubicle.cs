using UnityEngine;
using System.Collections.Generic;

public class Cubicle : MonoBehaviour {

    public Texture[] itemTextures;
    public AudioClip getItemSound;
    private int itemIndex;
    private bool recievedItem;
    private bool asking;
    private float cooldown = 3;
    private float timer = 0;
    private GettingItem getItem;
    private ScoreKeep score;

	// Use this for initialization
	void Start () 
    {
        gameObject.transform.FindChild("DesiredItem").renderer.material.mainTexture = null;
        recievedItem = false;
        asking = false;
        timer = cooldown;
        getItem = GameObject.FindGameObjectWithTag("Player").GetComponent<GettingItem>();
        score = GameObject.Find("PointsText").GetComponent<ScoreKeep>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timer < 0)
        {
            if (recievedItem == false && asking == false)
            {
                itemIndex = Random.Range(0, 4);
                gameObject.transform.FindChild("DesiredItem").renderer.material.mainTexture = itemTextures[itemIndex];
                gameObject.transform.FindChild("DesiredItem").gameObject.SetActive(true);
                asking = true;
            }
            else if(recievedItem == true)
            {
                gameObject.transform.FindChild("DesiredItem").gameObject.SetActive(false);
                asking = false;
                recievedItem = false;
                timer = cooldown;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if (getItem.getCurrentItem() == itemIndex)
            {
                recievedItem = true;
                getItem.setDelivered(true);
                score.addToPointsTotal();
                audio.clip = getItemSound;
                audio.Play();
            }
        }
    }
}
