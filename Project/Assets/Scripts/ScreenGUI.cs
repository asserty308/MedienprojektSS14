using UnityEngine;
using System.Collections;

public class ScreenGUI : MonoBehaviour 
{
    private string m_currentLabel;
    private bool m_showLabel;
    //private Font myFont;

    void Start()
    {
        //myFont = (Font)Resources.Load("Fonts/Cabin_Sketch/CabinSketch-Bold", typeof(Font));
        m_showLabel = true;
        m_currentLabel = GUILabels.moveString;

        Invoke("ToggleLabel", 10f);
    }

	void OnGUI()
    {
        /*GUIStyle mylabelStyle = new GUIStyle(GUI.skin.label);
        mylabelStyle.fontSize = 250;

        mylabelStyle.font = myFont;*/

        if (m_showLabel)
        {
            GUI.Label(new Rect((Screen.width >> 1) - m_currentLabel.Length * 3f, Screen.height >> 3, m_currentLabel.Length * 6f, 20f), m_currentLabel/*, mylabelStyle*/);
        }
    }

    void ToggleLabel()
    {
        m_showLabel = false;
    }
}

public struct GUILabels
{
    public static string moveString = "You can move with arrow keys and jump with space";

}
