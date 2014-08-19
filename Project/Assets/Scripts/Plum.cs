using UnityEngine;
using System.Collections;

public class Plum : MonoBehaviour {

	public PlayerScore scoreKeeper;
    public bool m_eaten;

	// Use this for initialization
	void Start () {
	
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
			scoreKeeper.plumEaten();
            gameObject.renderer.enabled = false;
            m_eaten = true;
		}
	}
}
