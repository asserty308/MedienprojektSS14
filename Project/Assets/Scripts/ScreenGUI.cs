using UnityEngine;
using System.Collections;

public class ScreenGUI : MonoBehaviour 
{
    private string m_currentLabel, m_scoreLabel;
    private bool m_showLabel;
	private GUIStyle m_currentLabelStyle, m_scoreLabelStyle;
    private PlayerScore m_playerScore;

    void Start()
    {
		Font font = (Font)Resources.Load("Fonts/Cabin_Sketch/CabinSketch-Bold");

        m_playerScore = GetComponent<PlayerScore>();
		m_currentLabelStyle = new GUIStyle();
		m_currentLabelStyle.font = font;
		m_currentLabelStyle.normal.textColor = Color.blue;
		m_currentLabelStyle.fontSize = 28;

		m_scoreLabelStyle = new GUIStyle();
		m_scoreLabelStyle.font = font;
		m_scoreLabelStyle.normal.textColor = Color.black;
		m_scoreLabelStyle.fontSize = 64;

		m_showLabel = true;
        m_currentLabel = GUILabels.moveString;
        m_scoreLabel = m_playerScore.getGUIScore();

        Invoke("ToggleLabel", 10f);
    }

	void OnGUI()
    {
        GUI.Label(new Rect(20f, 10f, m_scoreLabel.Length * 4f, 20f), m_scoreLabel, m_scoreLabelStyle);

        if (m_showLabel)
        {
           GUI.Label(new Rect((Screen.width >> 1) - m_currentLabel.Length * 6f, Screen.height >> 2, m_currentLabel.Length * 7f, 20f), m_currentLabel, m_currentLabelStyle);
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

    public void setLabelString(string label)
    {
        m_currentLabel = label;
        m_showLabel = true;
        Invoke("ToggleLabel", 10f);
    }
}

public struct GUILabels
{
    public static string moveString = "Use the arrow keys to move to the left or right and the spacebar to jump";
    public static string concatenateString = "Use left shift to contract";
}
