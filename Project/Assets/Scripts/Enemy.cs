using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    public bool moveLeft;
    public float speed;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 movement;

	    if (moveLeft)
        {
            movement = new Vector3(-Time.deltaTime*speed, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(Time.deltaTime*speed, 0.0f, 0.0f);
        }

        transform.position += movement;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBorder")
        {
            moveLeft = !moveLeft;
        }
        else if (other.tag == "Head" || other.tag == "Segment")
        {
            Destroy(this.gameObject);
        }
    }
}
