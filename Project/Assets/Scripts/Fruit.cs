using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour 
{
	public bool m_eaten;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (m_eaten && !audio.isPlaying)
		{
			Destroy(this.gameObject);
		}
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Head")
        {
			audio.Play();
			gameObject.renderer.enabled = false;
			m_eaten = true;
			Head head = other.gameObject.GetComponent<Head>();
			
			if(head.getNumberOfSegments() < 10){
				head.growNewSegment();
			}
        }
    }
}

	
	


