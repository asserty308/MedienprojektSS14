using UnityEngine;
using System.Collections;

public class ScreenGUI : MonoBehaviour 
{
    private string m_currentLabel, m_scoreLabel;
    private bool m_showLabel;
    private GUIStyle m_style;
    private PlayerScore m_playerScore;

    void Start()
    {
        m_playerScore = GetComponent<PlayerScore>();
        m_style = new GUIStyle();
        m_style.font = (Font)Resources.Load("Fonts/Cabin_Sketch/CabinSketch-Bold");
        m_style.normal.textColor = Color.blue;
        m_showLabel = true;
        m_currentLabel = GUILabels.moveString;
        m_scoreLabel = m_playerScore.getGUIScore();

        Invoke("ToggleLabel", 10f);
    }

	void OnGUI()
    {
        GUI.Label(new Rect(10f, 10f, m_scoreLabel.Length * 3.5f, 20f), m_scoreLabel, m_style);

        if (m_showLabel)
        {
           GUI.Label(new Rect((Screen.width >> 1) - m_currentLabel.Length * 3.5f, Screen.height >> 3, m_currentLabel.Length * 7f, 20f), m_currentLabel, m_style);
        }
    }

    void ToggleLabel()
    {
        m_showLabel = false;
    }

    public void updateScoreLabel(int score)
    {
        m_scoreLabel = "Score: " + score;
    }
}

public struct GUILabels
{
    public static string moveString = "Use the arrow keys to move to the left or right and the spacebar to jump";

}
