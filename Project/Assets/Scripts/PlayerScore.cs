using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour 
{
    public const int cherryPoints = 10;
    public const int plumPoints = 5;
    public const int applePoints = 50;
    public Head head; //needed to set segmentCount
	public int score;
    
    private int cherriesEaten, plumsEaten, deaths, multiplier;
    private bool appleEaten;
    private Segment successor;
    private ScreenGUI m_screenGUI;

	// Use this for initialization
	void Start () 
    {
    	DontDestroyOnLoad(gameObject);

        m_screenGUI = GetComponent<ScreenGUI>();
    	
        score = 0;
        cherriesEaten = 0;
        plumsEaten = 0;
        appleEaten = false;

        m_screenGUI.updateScoreLabel(this.score);
	}
	
	// Update is called once per frame
	void Update () 
    {
        score = cherriesEaten * cherryPoints + plumsEaten * plumPoints;
		
		multiplier = head.getNumberOfSegments() + 1;
		
        if (appleEaten)
            score += applePoints;

        m_screenGUI.updateScoreLabel(this.score);
	}

    public void cherryEaten()
    {
        cherriesEaten++;
    }

    public void plumEaten()
    {
        plumsEaten++;
    }

    public void appleEatenTrigger()
    {
        appleEaten = true;
    }
    
    public void addDeath(){
    	deaths++;
    }
    
    public int getMuliplier(){
    	return multiplier;
    }
    
    public int getDeaths(){
    	return deaths;
    }

    public string getGUIScore()
    {
        return "Score: " + score;
    }
    
}
