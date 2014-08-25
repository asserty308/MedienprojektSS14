using UnityEngine;
using System.Collections;

public class MoleActivator : MonoBehaviour 
{
    public Mole m_mole;
    public GameObject m_camera;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Head")
        {
            m_camera.gameObject.audio.Stop();
            m_mole.setActivated(true);

            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
    }
}
