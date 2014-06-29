using UnityEngine;
using System.Collections;

public class FoxLeg : MonoBehaviour 
{
    public bool moveUp;
    public float startX;

	// Use this for initialization
	void Start () 
    {
        this.startX = transform.position.x;
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

        this.transform.position = new Vector3(startX, transform.position.y, transform.position.z);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "FoxBody")
        {
            moveUp = false;
        }
        else if (coll.gameObject.tag == "Ground")
        {
            moveUp = true;
        }
    }
}
