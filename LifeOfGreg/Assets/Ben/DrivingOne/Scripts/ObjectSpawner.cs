using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public List<GameObject> carList = new List<GameObject>();
    public List<GameObject> peopleList = new List<GameObject>();

    float spawnTime = 2f;

    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            int carIndex = Random.Range(0, carList.Count - 1);
            spawnTime = Random.Range(1f,2f);
            int lane = Random.Range(0, 4);
            if (lane <= 1)//right
            {
                if (lane == 0)
                {
                    spawnCar(new Vector3(1f, player.position.y + 10f, -.1f), carList[carIndex], false);
                }
                else
                {
                    spawnCar(new Vector3(3f, player.position.y + 10f, -.1f), carList[carIndex], false);
                }
            }
            else//left
            {
                if (lane == 2)
                {
                    spawnCar(new Vector3(-1f, player.position.y + 10f, -.1f), carList[carIndex], true);
                }
                else
                {
                    spawnCar(new Vector3(-3f, player.position.y + 10f, -.1f), carList[carIndex], true);
                }
            }

        }
	}


	//

    void spawnCar(Vector3 position, GameObject gameObject,bool fliped)
    {
        GameObject car = Instantiate(gameObject) as GameObject;
        car.transform.position = position;
        if (fliped)
        {
            car.transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        }
    }
}
