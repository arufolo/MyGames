using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndlessRoad : MonoBehaviour {

    public GameObject rightRoad;
    public GameObject leftRoad;

    public GameObject rightBuilding;
    public GameObject leftBuilding;

    public Transform player;

    Stack<Road> loadedRoads = new Stack<Road>();
    Stack<Building> loadedBuildings = new Stack<Building>();

    Queue<Road> activeRoads = new Queue<Road>();
    Queue<Building> activeBuildings = new Queue<Building>();

    float oldYPosition;

    float buildingYPosition;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            GameObject right = Instantiate(rightRoad) as GameObject;
            GameObject left = Instantiate(leftRoad) as GameObject;
            right.SetActive(false);
            left.SetActive(false);
            loadedRoads.Push(new Road(right, left));
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject right = Instantiate(rightBuilding) as GameObject;
            GameObject left = Instantiate(leftBuilding) as GameObject;
            right.SetActive(false);
            left.SetActive(false);
            loadedBuildings.Push(new Building(right, left));
        }
        for (int i = -3; i < 2; i++)
        {
            oldYPosition = i * 4;
            Road road = loadedRoads.Pop();
            road.setActive(true);
            road.left.transform.position = new Vector2(-2.5f, oldYPosition + 8f);
            road.right.transform.position = new Vector2(2.5f, oldYPosition + 8f);

            activeRoads.Enqueue(road);
        }

        buildingYPosition = 0;
        Building buildings = loadedBuildings.Pop();
        buildings.setActive(true);
        buildings.left.transform.position = new Vector3(5f, 0f, -3.211489f);
        buildings.right.transform.position = new Vector3(-5f, 0f, -3.211489f);

        oldYPosition = 0f;
	}

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > oldYPosition)
        {
            oldYPosition = oldYPosition + 4;
            Road road = loadedRoads.Pop();
            road.setActive(true);
            road.left.transform.position = new Vector2(-2.5f, oldYPosition + 8f);
            road.right.transform.position = new Vector2(2.5f, oldYPosition + 8f);

            activeRoads.Enqueue(road);
        }
        if (activeRoads.Count > 6)
        {
            Road road = activeRoads.Dequeue();
            road.setActive(false);
            loadedRoads.Push(road);
        }
        if (player.position.y > buildingYPosition)
        {
            buildingYPosition = buildingYPosition + 96;
            Building buildings = loadedBuildings.Pop();
            buildings.setActive(true);
            buildings.left.transform.position = new Vector3(5f, buildingYPosition, -3.211489f);
            buildings.right.transform.position = new Vector3(-5f, buildingYPosition, -3.211489f);

            activeBuildings.Enqueue(buildings);
        }
        if (activeBuildings.Count > 2)
        {
            Building buildings = activeBuildings.Dequeue();
            buildings.setActive(false);
            loadedBuildings.Push(buildings);
        }
	}

    class Road
    {
        public GameObject right;
        public GameObject left;
        public Road(GameObject right, GameObject left)
        {
            this.right = right;
            this.left = left;
        }

        public void setActive(bool active)
        {
            right.SetActive(active);
            left.SetActive(active);
        }
    }


	//
    class Building
    {
        public GameObject right;
        public GameObject left;
        public Building(GameObject right, GameObject left)
        {
            this.right = right;
            this.left = left;
        }

        public void setActive(bool active)
        {
            right.SetActive(active);
            left.SetActive(active);
        }
    }
}
