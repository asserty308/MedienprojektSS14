using UnityEngine;
using System.Collections;

public class smooth2Dfollow : MonoBehaviour {

	public Transform target;
	public float dampfactor;
	private Vector3 velocity;
	public float targetPosOnScreenX;
	public float targetPosOnScreenY;
	private float lastDeltaY;
	public float upperFollowBorder;
	

	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
		upperFollowBorder = 5f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target){
			Vector3 targetPoint = camera.ViewportToWorldPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(targetPosOnScreenX, 
																					  targetPosOnScreenY, 
																					  targetPoint.z));
			
			//The camera should follow in Y-direction only if the caterpillar is approaching the south screenborder 
			if(delta.y > lastDeltaY && delta.y < upperFollowBorder){
				delta.y = 0f;
			}
			
			
			Vector3 destination = transform.position + delta + new Vector3(0f, 0f, -10f);
			
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampfactor);
		
		
		}
	}
}
