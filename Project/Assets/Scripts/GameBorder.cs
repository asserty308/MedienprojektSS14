using UnityEngine;
using System.Collections;

public class GameBorder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D (Collider2D collider)
    {
        if(collider.tag == "Head"){
			CheckpointManager checkpointManager = collider.GetComponent<CheckpointManager>();
			GameObject currentCheckpointObject = checkpointManager.currentCheckpoint;
			Checkpoint currentCheckpoint = currentCheckpointObject.GetComponent<Checkpoint>();
			
			Destroy(collider.gameObject);
			currentCheckpoint.respawn();
        }else{
			//destroy objects falling out of the game
			Destroy(collider.gameObject);	
        }
        
        
    }
}
