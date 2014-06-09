using UnityEngine;
using System.Collections;

public class Head : MonoBehaviour {

    public Segment successor;
	public bool grounded;
	public LayerMask mask;
	public Vector2 dir;
	public GameObject newSeg;
	public bool facingRight;
	public Vector3 lastPosition;
	
	// Use this for initialization
	void Start () {
		dir = transform.right;
		facingRight = true;
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidbody2D.AddForce(transform.up * 500f);
        }
        
        if(transform.position.x > lastPosition.x){
        	facingRight = true;
		}else if(transform.position.x < lastPosition.x){
			facingRight = false;
		}
		
		grounded = Physics2D.OverlapCircle(transform.position, 0.45f, mask);
		
		lastPosition = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		rigidbody2D.AddForce(dir * Input.GetAxis("Horizontal") * 20.0f);
		
		transform.rotation = Quaternion.Euler(Vector3.zero); //Lock rotation
	}
	
	
	public void growNewSegment(){
		GameObject newSegment = (GameObject)Instantiate(newSeg);
		Segment nextSeg = successor;
		float distance = -0.6f;
		int i = 1;
		
		Segment newSegScript = newSegment.GetComponent<Segment>();
		newSegScript.successor = null;
		newSegScript.head = this;
		
		if(nextSeg){
			while(nextSeg.successor){
				nextSeg = nextSeg.successor;
				i++;
			}
		
			newSegScript.predecessor = nextSeg.gameObject.transform;
			nextSeg.successor = newSegment.GetComponent<Segment>();
			newSegment.layer = LayerMask.NameToLayer("seg" + (++i));
			
			
		}else{
	
			newSegScript.predecessor = this.transform;
			this.successor = newSegment.GetComponent<Segment>();
			newSegment.layer = LayerMask.NameToLayer("seg" + i);
		}
		
		
		newSegment.transform.position = this.transform.position + new Vector3(i * distance, 0f, 0f);
	}
	
	public int getNumberOfSegments(){
		Segment seg = successor;
		int i = seg ? 1 : 0;
		while(seg.successor){
			seg = seg.successor;
			i++;
		}
		return i;	
	}
}
