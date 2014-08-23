using UnityEngine;
using System.Collections;

public class Stomper : MonoBehaviour {

	public float knockbackForce;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other){
	
		if (other.gameObject.tag == "Head")
		{
			Head head = other.gameObject.GetComponent<Head>();
			Segment segment = head.successor != null ? head.successor : null;
			
			if (segment == null)
			{
				CheckpointManager checkpointManager = other.gameObject.GetComponent<CheckpointManager>();
				GameObject currentCheckpointObject = checkpointManager.currentCheckpoint;
				Checkpoint currentCheckpoint = currentCheckpointObject.GetComponent<Checkpoint>();
				
				Destroy(head.gameObject);
				currentCheckpoint.respawn();
				return;
			}
			
			while (segment.successor != null)
			{
				segment = segment.successor;
			}
			
			Destroy(segment.gameObject);
			
			//Little Knockback on impact
			Vector3 knockbackDirection = head.currentFacingRight ? -(other.transform.right) : other.transform.right; 
			other.gameObject.rigidbody2D.velocity = knockbackDirection * knockbackForce + new Vector3(0f, 10f, 0);
			//
			
		}
		else if (other.gameObject.tag == "Segment")
		{
			Segment segment = other.gameObject.GetComponent<Segment>();
			
			while (segment.successor != null)
			{
				segment = segment.successor;
			}
			
			Destroy(segment.gameObject);
			
			//Little Knockback on impact
			Head head = segment.head;
			Vector3 knockbackDirection = head.currentFacingRight ? other.transform.right : -other.transform.right; 
			head.gameObject.rigidbody2D.velocity = knockbackDirection * knockbackForce + new Vector3(0f, 10f, 0);
			//
		}
	}
}
