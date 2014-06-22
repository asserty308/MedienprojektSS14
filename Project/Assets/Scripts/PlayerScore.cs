using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour 
{
    public const int segmentPoints = 25;
    public const int cherryPoints = 10;
    public const int plumPoints = 5;
    public const int applePoints = 50;
    public GUIText scoreText;
    public Head head; //needed to set segmentCount

    private int score, segmentCount, cherriesEaten, plumsEaten;
    private bool appleEaten;
    private Segment successor;

	// Use this for initialization
	void Start () 
    {
        segmentCount = 1;

        if (head.successor != null)
        {
            successor = head.successor;
            segmentCount++;

            while (successor.successor != null)
            {
                successor = successor.successor;
                segmentCount++;
            }
        }

        score = segmentCount * segmentPoints;
        cherriesEaten = 0;
        plumsEaten = 0;
        appleEaten = false;

        updateGUIScore();
	}
	
	// Update is called once per frame
	void Update () 
    {
        segmentCount = 1; //1 for the head

        if (head.successor != null)
        {
            successor = head.successor;
            segmentCount++;

            while (successor.successor != null)
            {
                successor = successor.successor;
                segmentCount++;
            }
        }

        score = segmentCount * segmentPoints;

        updateGUIScore();
	}

    void addScore(int value)
    {
        score += value;
        updateGUIScore();
    }

    void updateGUIScore()
    {
        scoreText.text = "Score: " + score;
    }
}
