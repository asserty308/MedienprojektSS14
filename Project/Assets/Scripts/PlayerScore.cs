using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour 
{
    public const int segmentPoints = 25;
    public const int cherryPoints = 10;
    public const int plumPoints = 5;
    public const int applePoints = 50;
    public Head head; //needed to set segmentCount
	public int score;
    
    private int segmentCount, cherriesEaten, plumsEaten;
    private bool appleEaten;
    private Segment successor;
    private ScreenGUI m_screenGUI;

	// Use this for initialization
	void Start () 
    {
    	DontDestroyOnLoad(gameObject);

        m_screenGUI = GetComponent<ScreenGUI>();
    	
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

        m_screenGUI.updateScoreLabel(this.score);
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

        m_screenGUI.updateScoreLabel(this.score);
	}

    void addScore(int value)
    {
        score += value;
        getGUIScore();
    }

    public string getGUIScore()
    {
        return "Score: " + score;
    }
    
}
