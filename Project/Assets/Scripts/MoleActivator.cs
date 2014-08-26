using UnityEngine;
using System.Collections;

public class MoleActivator : MonoBehaviour 
{
    public Mole m_mole;
    public GameObject m_camera;
    
    private bool musicFadingIn;
    
    void start(){
    	musicFadingIn = false;
    }
    
	// Update is called once per frame
	void Update () {
		if(musicFadingIn){
			fadeNewMusicIn();
		}
		if(m_camera.audio.volume <= 0.0f && audio.volume == 1.0f){
			musicFadingIn = false;
		}
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Head")
        {
            m_mole.setActivated(true);

            if (!audio.isPlaying)
            {
                audio.Play();
				musicFadingIn = true;
            }
        }
		
    }
    
    void fadeNewMusicIn(){
    	audio.volume += 0.2f * Time.deltaTime;
    	m_camera.audio.volume -= 0.2f * Time.deltaTime;
    }
}
