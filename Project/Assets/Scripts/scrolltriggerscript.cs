using UnityEngine;
using System.Collections;

public class scrolltriggerscript : MonoBehaviour {

	public scrollscript scroller;
	public smooth2Dfollow playerFollower;
	public Camera cam;
	
	private float triggerBorderOffset;

	// Use this for initialization
	void Start () {
		triggerBorderOffset = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		float rightTriggerBorder = playerFollower.targetPosOnScreenX + triggerBorderOffset;
		float leftTriggerBorder = playerFollower.targetPosOnScreenX - triggerBorderOffset;
		
		if(cam.WorldToViewportPoint(transform.position).x > rightTriggerBorder){
			scroller.scrollspeed = 0.1f;
		}else if (cam.WorldToViewportPoint(transform.position).x < leftTriggerBorder){
			scroller.scrollspeed = -0.1f;
		}else{
			scroller.scrollspeed = 0f;
		}

	}
}
