using UnityEngine;
using System.Collections;

public class GettingItem : MonoBehaviour 
{
    private int currentItem;
    private bool isDelivered;
    public Texture[] itemTextures;

	// Update is called once per frame
    void Start()
    {
        currentItem = -1;
        isDelivered = false;
        gameObject.transform.FindChild("GregItem").renderer.material.mainTexture = null;
    }
	void Update () 
    {
        if (isDelivered == true)
        {
            gameObject.transform.FindChild("GregItem").gameObject.SetActive(false);
            isDelivered = false;
        }
	}

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.name == "mail")
        {
            gameObject.transform.FindChild("GregItem").renderer.material.mainTexture = itemTextures[0];
            gameObject.transform.FindChild("GregItem").gameObject.SetActive(true);
            currentItem = 0;
        }

        if (coll.gameObject.name == "watercooler")
        {
            gameObject.transform.FindChild("GregItem").renderer.material.mainTexture = itemTextures[3];
            gameObject.transform.FindChild("GregItem").gameObject.SetActive(true);
            currentItem = 3;
        }

        if (coll.gameObject.name == "printer")
        {
            gameObject.transform.FindChild("GregItem").renderer.material.mainTexture = itemTextures[1];
            gameObject.transform.FindChild("GregItem").gameObject.SetActive(true);
            currentItem = 1;
        }

        if (coll.gameObject.name == "supplies")
        {
            gameObject.transform.FindChild("GregItem").renderer.material.mainTexture = itemTextures[2];
            gameObject.transform.FindChild("GregItem").gameObject.SetActive(true);
            currentItem = 2;
        }
    }

    public void setDelivered(bool d)
    {
        isDelivered = d;
    }

    public int getCurrentItem()
    {
        return currentItem;
    }
}
