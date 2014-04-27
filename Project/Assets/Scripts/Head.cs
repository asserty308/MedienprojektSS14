using UnityEngine;
using System.Collections;

public class Head : MonoBehaviour {

	bool grounded;
	public LayerMask mask;
	public Vector2 dir;
	
	// Use this for initialization
	void Start () {
		dir = transform.right;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
//		rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * 10.0f, rigidbody2D.velocity.y);
		
		rigidbody2D.AddForce(dir * Input.GetAxis("Horizontal") * 20.0f);
		
		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			rigidbody2D.AddForce(transform.up * 500f);
		}
		
		grounded = Physics2D.OverlapCircle(transform.position, 0.45f, mask);
		
		transform.rotation = Quaternion.Euler(Vector3.zero); //Lock rotation
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.layer == 8){
			//dir = col.gameObject.transform.right;	
		}

	}
	
	void OnCollisionStay2D(Collision2D col){
		
	}
}
