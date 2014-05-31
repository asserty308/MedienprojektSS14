using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Respawn"){
			currentCheckpoint = other.gameObject;
		}
	
	}
}
