using UnityEngine;
using System.Collections;

public class ScoreKeep : MonoBehaviour 
{
    private int points;

    // Use this for initialization
    void Start()
    {
        points = 0;
    }

    void Update()
    {
        guiText.text = "Delievered: " + points + " / "  + "10";
    }

    public void addToPointsTotal()
    {
        points++;
    }

    public int getScore()
    {
        return points;
    }
}
