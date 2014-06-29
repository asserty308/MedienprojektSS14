using UnityEngine;
using System.Collections;

public class deathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Head" || other.gameObject.tag == "Segment"){
			if(other.gameObject.tag == "Head"){
				CheckpointManager checkpointManager = other.gameObject.GetComponent<CheckpointManager>();
				if(checkpointManager != null){
					GameObject currentCheckpointObject = checkpointManager.currentCheckpoint;
					Checkpoint currentCheckpoint = currentCheckpointObject.GetComponent<Checkpoint>();
			
					Destroy(other.gameObject);
					currentCheckpoint.respawn();
				}
			}else{
				Destroy(other.gameObject);	
			}
		}
	}
}
