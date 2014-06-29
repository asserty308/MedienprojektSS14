using UnityEngine;
using System.Collections;

public class CameraControllpoint : MonoBehaviour {

	public float EnterCaterpillarCamPosX;
	public float EnterCaterpillarCamPosY;
	
	public float ExitCaterpillarCamPosX;
	public float ExitCaterpillarCamPosY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Head"){
			smooth2Dfollow sm2df = Camera.main.GetComponent<smooth2Dfollow>();
			
			sm2df.targetPosOnScreenX = this.EnterCaterpillarCamPosX;
			sm2df.targetPosOnScreenY = this.EnterCaterpillarCamPosY;
		}
		
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Head"){
			smooth2Dfollow sm2df = Camera.main.GetComponent<smooth2Dfollow>();
			
			sm2df.targetPosOnScreenX = this.ExitCaterpillarCamPosX;
			sm2df.targetPosOnScreenY = this.ExitCaterpillarCamPosY;
		}
	}
}
