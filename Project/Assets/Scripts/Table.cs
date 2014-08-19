using UnityEngine;
using System.Collections;

public class Table : MonoBehaviour 
{
    public GameObject m_moleActivator;
    public GameObject m_camera;
    private bool m_activated;

    void Start()
    {
        m_activated = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!m_activated)
        {
            m_moleActivator.gameObject.audio.Stop();
            m_camera.gameObject.audio.Play();
        }

        m_activated = true;
    }
}
