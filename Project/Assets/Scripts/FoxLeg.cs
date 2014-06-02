using UnityEngine;
using System.Collections;

public class FoxLeg : MonoBehaviour 
{
    public bool moveUp;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 movingVector;

	    if (moveUp)
        {
            movingVector = new Vector3(0f, Time.deltaTime, 0f);
        }
        else
        {
            movingVector = new Vector3(0f, -Time.deltaTime, 0f);
        }

        this.transform.position += movingVector;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("trigger Enter");
        if (coll.gameObject.tag == "FoxBody")
        {
            moveUp = false;
        }
        else if (coll.gameObject.tag == "Ground")
        {
            moveUp = true;
        }
    }

    /*void OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log("Collision Stay");
        if (coll.gameObject.tag == "FoxBody")
        {
            moveUp = false;
        }
        else if (coll.gameObject.tag == "Ground")
        {
            moveUp = true;
        }
    }*/
}
