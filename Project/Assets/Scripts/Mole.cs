using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour 
{
    public float speedFactor;
    public float knockbackForce;

    private bool activated;
    private Vector3 moveVector;
    private float startPositionX;

	void Start () 
    {
        activated = false;
        moveVector = new Vector3(1f, moleMoveFunction(), 0f);
        startPositionX = transform.position.x;
	}
	
	void Update () 
    {
	    if (activated)
        {
            transform.position += Time.deltaTime * moveVector;
            moveVector = new Vector3(speedFactor, moleMoveFunction(), 0f);
        }
	}

    float moleMoveFunction()
    {
        float dx = transform.position.x - startPositionX;
        return Mathf.Sin(dx);
    }

    public void setActivated(bool state)
    {
        activated = state;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Head")
        {
            Head head = other.GetComponent<Head>();
            Segment segment = head.successor != null ? head.successor : null;

            if (segment == null)
            {
                CheckpointManager checkpointManager = other.GetComponent<CheckpointManager>();
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
            Vector3 knockbackDirection = head.facingRight ? -(other.transform.right) : other.transform.right;
            other.gameObject.rigidbody2D.velocity = knockbackDirection * knockbackForce + new Vector3(0f, 10f, 0);
            //

        }
        else if (other.tag == "Segment")
        {
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
