using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scrolltriggerscript : MonoBehaviour {

	public List<scrollscript> backgroundLevels;
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
		
        if (backgroundLevels != null)
        {
            if (cam.WorldToViewportPoint(transform.position).x > rightTriggerBorder)
            {
                backgroundLevels[0].scrollspeed = 0.1f;
                backgroundLevels[1].scrollspeed = 0.07f;
            }
            else if (cam.WorldToViewportPoint(transform.position).x < leftTriggerBorder)
            {
				backgroundLevels[0].scrollspeed = -0.1f;
				backgroundLevels[1].scrollspeed = -0.07f;
            }
            else
            {
            	foreach(scrollscript s in backgroundLevels){
            		s.scrollspeed = 0.0f;
            	}
            }
        }
	}
}
