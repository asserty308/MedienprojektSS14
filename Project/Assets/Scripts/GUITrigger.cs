using UnityEngine;
using System.Collections;

public class GUITrigger : MonoBehaviour 
{
    public GameObject m_gameController;
    private ScreenGUI m_guiScript;

    void Start()
    {
        m_guiScript = m_gameController.GetComponent<ScreenGUI>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Head" || collider.tag == "Segment")
        {
            m_guiScript.setLabelString(GUILabels.concatenateString);
        }
    }
}
