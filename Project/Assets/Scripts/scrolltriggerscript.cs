using UnityEngine;
using System.Collections;

public class scrolltriggerscript : MonoBehaviour {

	public scrollscript scroller;
	public Camera cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(cam.WorldToViewportPoint(transform.position).x > 0.53f){
			scroller.scrollspeed = 0.1f;
		}else if (cam.WorldToViewportPoint(transform.position).x < 0.49f){
			scroller.scrollspeed = -0.1f;
		}else{
			scroller.scrollspeed = 0f;
		}

			
		//Keep only until real player-movement is implemented!!!
		rigidbody2D.velocity = new Vector2(Time.deltaTime * Input.GetAxis("Horizontal") * 150f, 0f);
		
	}
}
