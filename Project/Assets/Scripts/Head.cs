using UnityEngine;
using System.Collections;

public class Head : MonoBehaviour {

    public Segment successor;
	public bool grounded;
	public LayerMask mask;
	public Vector2 dir;
	public GameObject newSeg;
	
	// Use this for initialization
	void Start () {
		dir = transform.right;
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidbody2D.AddForce(transform.up * 500f);
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
		
		rigidbody2D.AddForce(dir * Input.GetAxis("Horizontal") * 20.0f);
		
		grounded = Physics2D.OverlapCircle(transform.position, 0.45f, mask);
		
		transform.rotation = Quaternion.Euler(Vector3.zero); //Lock rotation
	}
	
	public void growNewSegment(){
		GameObject newSegment = (GameObject)Instantiate(newSeg);
		Segment nextSeg = successor;
		float distance = -0.6f;
		int i = 1;
		
		Segment newSegScript = newSegment.GetComponent<Segment>();
		newSegScript.successor = null;
		
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
}
