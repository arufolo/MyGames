using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

    public GameObject cursor;

    Vector2 prevPosition;

    Transaction transaction;

    public bool unflip = false;

    int updatecount;

	// Use this for initialization
	void Start () {
        prevPosition = cursor.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (unflip && updatecount <= 0)
        {
            transaction.flip();
            unflip = false;
        }
        else
        {
            updatecount--;
        }

        if (Input.GetMouseButtonDown(0))
        {
            cursor.SetActive(true);
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = (int)(position.x * 10f);
            int y = (int)(position.y * 10f);
            x = x - x%8;
            y = y - y%8;
            position = new Vector2((((float)x) / 10f) - .4f, (((float)y) / 10f) - .4f);

            if (position.x >= -14f && position.x <= -3.6f && position.y <= -2.8f && position.y >= -10f)
            {
                cursor.transform.position = position;
                if (Vector2.Distance(prevPosition, position) <= 1f)
                {
                    cursor.SetActive(false);


                    RaycastHit2D hit = Physics2D.Raycast(prevPosition, Vector2.zero, 20f, 1 << LayerMask.NameToLayer("Food"));
                    RaycastHit2D hit2 = Physics2D.Raycast(position, Vector2.zero, 20f, 1 << LayerMask.NameToLayer("Food"));
                    GameObject first = null;
                    GameObject second = null;

                    if (hit.collider != null)
                    {
                        first = hit.collider.gameObject;
                    }
                    if (hit2.collider != null)
                    {
                        second = hit2.collider.gameObject;
                    }

                    transaction = new Transaction(first,second);
                    transaction.flip();
                    unflip = true;
                    updatecount = 50;

                    position = new Vector2(100, 100);
                }
                prevPosition = position;
            }
        }
	}

    class Transaction
    {
        GameObject first;
        GameObject second;
        public Transaction(GameObject first, GameObject second)
        {
            this.first = first;
            this.second = second;
        }

        public void flip()
        {
			if (first != null && second != null) {
				Vector2 position = first.transform.position;
				first.transform.position = (Vector2)second.transform.position;
				second.transform.position = position;
			}
          
         
        }
    }
}
