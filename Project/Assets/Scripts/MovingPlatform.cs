using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
    public bool moveLeft, leftPlatform;
    public float speed, midPosX;
    private float startX;

	// Use this for initialization
	void Start () 
    {
        startX = transform.position.x;
	}
	
	// Update is called once per frame
    void Update()
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

        if (leftPlatform)
        {
            if ((transform.position.x < startX) || (transform.position.x > midPosX))
            {
                moveLeft = !moveLeft;
            }
        }
        else
        {
            if ((transform.position.x > startX) || (transform.position.x < midPosX))
            {
                moveLeft = !moveLeft;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingGroundSegment")
        {
            moveLeft = !moveLeft;
        }
    }
}
