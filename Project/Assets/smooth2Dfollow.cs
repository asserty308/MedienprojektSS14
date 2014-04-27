using UnityEngine;
using System.Collections;

public class smooth2Dfollow : MonoBehaviour {

	public Transform target;
	public float dampfactor;
	private Vector3 velocity;
	public Vector3 standoff;
	

	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if(target){
			Vector3 targetPoint = camera.ViewportToWorldPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, targetPoint.z));
			Vector3 destination = transform.position + delta + standoff;
			
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampfactor);
		
		
		}
	}
}
