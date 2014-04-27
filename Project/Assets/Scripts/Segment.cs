using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour {

	public Transform successor;
	bool grounded;
	public LayerMask mask;
	
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		Vector2 gap = successor.position - transform.position;
		float dis = Vector2.Distance(transform.position, successor.position);
		
		grounded = Physics2D.OverlapCircle(transform.position, 0.45f, mask);
		
		if(dis > 0.85f){
			rigidbody2D.velocity = gap * 10f * gap.sqrMagnitude;
		}else{
			if(grounded){
				rigidbody2D.velocity = Vector2.zero;	
			}else{
				rigidbody2D.velocity = (Physics2D.gravity * 20f * Time.deltaTime);
				
			}
		}
		
		transform.rotation = Quaternion.Euler(Vector3.zero); //Lock rotation
		
	}
}
