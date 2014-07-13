using UnityEngine;
using System.Collections;

public class RhinoBeetle : MonoBehaviour {

	public LayerMask sightLayer;
	public float knockbackForce;
	public float visionRange;
	public bool lookingLeft;
	public Vector3 originOfSightOffset;
	
	private Vector3 startPos;
	private bool charging;
	private bool returning;
	private bool facingLeft;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		charging = false;
		returning = false;
		facingLeft = lookingLeft;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 origin = transform.position + originOfSightOffset;
		RaycastHit2D hit;
		
		if(lookingLeft){
			hit = Physics2D.Raycast(origin, -transform.right, visionRange, sightLayer);
		}else{
			hit = Physics2D.Raycast(origin, transform.right, visionRange, sightLayer);
		}
		
		if(hit.collider){
			if(hit.collider.tag == "Head" || hit.collider.tag == "Segment"){
				charge();
				charging = true;
			}
		}
		
		if(returning){
			if(lookingLeft){
				transform.position += new Vector3(5f, 0f, 0f) * Time.deltaTime;
			}else{
				transform.position += new Vector3(-5f, 0f, 0f) * Time.deltaTime;
			}
		}
		
		if(Mathf.Abs(startPos.x - transform.position.x) < 1f){
			returning = false;
			charging = false;
			
			if(lookingLeft){
				if(!facingLeft){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					facingLeft = true;
				}
			}else{
				if(facingLeft){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					facingLeft = false;
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "EnemyBorder" || other.tag == "InvisibleBorder" || other.tag == "Head" || other.tag == "Segment"){
			rigidbody2D.velocity = Vector2.zero;
			charging = false;
			returning = true;
			
			if(lookingLeft){
				if(facingLeft){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					facingLeft = false;
				}
			}else{
				if(!facingLeft){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					facingLeft = true;
				}
			}
			if (other.tag == "Head"){
				Head head = other.GetComponent<Head>();
				Segment segment = head.successor != null ? head.successor : null;
			
				if (segment == null){
					CheckpointManager checkpointManager = other.GetComponent<CheckpointManager>();
					GameObject currentCheckpointObject = checkpointManager.currentCheckpoint;
					Checkpoint currentCheckpoint = currentCheckpointObject.GetComponent<Checkpoint>();
				
					Destroy(head.gameObject);
					currentCheckpoint.respawn();
					return;
				}
			
				while (segment.successor != null){
					segment = segment.successor;
				}
			
				Destroy(segment.gameObject);
			
				//Little Knockback on impact
				Vector3 knockbackDirection = head.facingRight ? -(other.transform.right) : other.transform.right; 
				other.gameObject.rigidbody2D.velocity = knockbackDirection * knockbackForce + new Vector3(0f, 10f, 0);
				//
			}
			
			if (other.tag == "Segment"){
				Segment segment = other.GetComponent<Segment>();
			
				while (segment.successor != null)
				{
					segment = segment.successor;
				}
			
				Destroy(segment.gameObject);
			
				//Little Knockback on impact
				Head head = segment.head;
				Vector3 knockbackDirection = head.facingRight ? other.transform.right : -other.transform.right; 
				head.gameObject.rigidbody2D.velocity = knockbackDirection * knockbackForce + new Vector3(0f, 10f, 0);
				//
			}
		
		}
	}
	
	void charge(){
		if(!charging && !returning){
			if(lookingLeft){
				rigidbody2D.velocity = -transform.right * 15f; 
			}else{
				rigidbody2D.velocity = transform.right * 15f; 
			}
		}
	}
	

}
