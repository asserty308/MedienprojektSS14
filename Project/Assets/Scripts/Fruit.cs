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
            m_eaten = true;
			audio.Play();
			gameObject.renderer.enabled = false;
            gameObject.collider2D.enabled = false;

			Head head = other.gameObject.GetComponent<Head>();
			head.growNewSegment();
        }
    }
}

	
	


