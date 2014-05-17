using System.Collections;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public Transform predecessor;
    public Segment successor;
    public float contractionLimit;
    private float scalingFactor;
    private float segmentRadius;
    private	float distanceLimit;
    private float step;
    private bool grounded, contracted;
    public LayerMask mask;

    private void Start()
    {
    	scalingFactor = 20f;
		segmentRadius = 0.45f;
		distanceLimit = 0.6f;
		step = 0.0625f;
		
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (predecessor != null)
        {
            Vector2 gap = predecessor.position - transform.position;
            float dis = Vector2.Distance(transform.position, predecessor.position);

            grounded = Physics2D.OverlapCircle(transform.position, segmentRadius, mask);

            if (Input.GetKey(KeyCode.LeftControl))
            {
                contracted = true;
            }else{
            	contracted = false;
            }
            
			if(contracted){
				if(dis > segmentRadius/2f){
					rigidbody2D.AddForce(gap * 1000f);
				}
			}else{
				contractionLimit = gap.sqrMagnitude > distanceLimit ? gap.sqrMagnitude : Mathf.Clamp(contractionLimit - step, 0f, gap.sqrMagnitude);
			}
	
			rigidbody2D.velocity = gap * scalingFactor * contractionLimit;
                
            if(Mathf.Abs(0 - contractionLimit) < Mathf.Epsilon){
                if (grounded)
                    {
                    	   rigidbody2D.velocity = Vector2.zero;
                    }
                    else
                    {
                    	   rigidbody2D.velocity = (Physics2D.gravity * scalingFactor * Time.deltaTime);
                    }
            }
      
        }

        transform.rotation = Quaternion.Euler(Vector3.zero); //Lock rotation
    }
}