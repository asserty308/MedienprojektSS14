using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {

    public PlayerScore playerScore;
	public GameObject respawnable;
	public LayerMask mask;
	public List<scrollscript> backgroundLevels;
	public PlayerScore scoreController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void respawn(){
		scoreController.addDeath();
	
		GameObject newPlayer = (GameObject)Instantiate(respawnable);
		newPlayer.transform.position = this.transform.position;
		newPlayer.layer = LayerMask.NameToLayer("Head");
		
		smooth2Dfollow sm2df = Camera.main.GetComponent<smooth2Dfollow>();
		
		sm2df.target = newPlayer.transform;
		
		scrolltriggerscript scrolltrigger = newPlayer.GetComponent<scrolltriggerscript>();
		scrolltrigger.cam = Camera.main;
		scrolltrigger.playerFollower = sm2df;
		scrolltrigger.backgroundLevels = backgroundLevels;
		
		Head newHead = newPlayer.GetComponent<Head>();
		newHead.successor = null;
		newHead.mask = mask;
		newHead.newSeg = Resources.Load<GameObject>("Segment");
		newHead.grounded = true;

		for(int i = 0; i < 5; i++){
			newHead.growNewSegment();
		}

        playerScore.head = newHead;
	}
}
