using UnityEngine;
using System.Collections;

public class Table : MonoBehaviour 
{
    public GameObject m_moleActivator;
    public GameObject m_camera;
    
    private bool m_activated;
	private bool musicFadingIn;
	
    void Start()
    {
        m_activated = false;
        musicFadingIn = false;
    }
    
    void Update(){
    	if(musicFadingIn){
    		fadeNewMusicIn();
    	}
    	if(m_moleActivator.audio.volume <= 0.0f && m_camera.audio.volume == 1.0f){
    		m_moleActivator.audio.Stop();
    		musicFadingIn = false;
    	}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!m_activated)
        {
            m_camera.audio.Play();
			musicFadingIn = true;
        }

        m_activated = true;
        
    }
    
    void fadeNewMusicIn(){
    	m_camera.audio.volume += 0.2f * Time.deltaTime;
    	m_moleActivator.audio.volume -= 0.2f * Time.deltaTime;
    }
}
