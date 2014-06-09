using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
    public bool moveLeft, leftPlatform;
    public float speed, midPosX;
    private float startX;
	public Vector3 movement;
	public Vector3 lockedPostition;

	// Use this for initialization
	void Start () 
    {
        startX = transform.position.x;
        lockedPostition = this.transform.position;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            movement = new Vector3(-speed, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(speed, 0.0f, 0.0f);
        }

		rigidbody2D.velocity = movement;


        if (leftPlatform)
        {
            if ((transform.position.x < startX) )
            {
                moveLeft = false;
            }
			if(transform.position.x > midPosX){
				moveLeft = true;
			}
        }
        else
        {
            if ((transform.position.x > startX)){ 
                moveLeft = true;
            }
            
			if(transform.position.x < midPosX){
				moveLeft = false;	
			}
        }
        
        //Lock y- and z-axis
        this.transform.position = new Vector3(transform.position.x, lockedPostition.y, lockedPostition.z);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingGroundSegment")
        {
            moveLeft = !moveLeft;
        }
        
        if(other.gameObject.tag == "Head" || other.gameObject.tag == "Segment"){
        	if(Input.GetAxis("Horizontal") == 0 && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift)){
				other.rigidbody.velocity = this.rigidbody2D.velocity;
        	}
        }
	}
    
}
