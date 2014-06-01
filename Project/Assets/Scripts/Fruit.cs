using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Head")
        {
            Destroy(this.gameObject);
//			newHead.growNewSegment();

        }
    }
}
