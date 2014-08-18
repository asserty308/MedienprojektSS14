using UnityEngine;
using System.Collections;

public class MoleCheckpoint : Checkpoint {

	public Mole mole;
	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void respawn(){
		base.respawn();
		mole.gameObject.transform.position = mole.startPosition;
		mole.setActivated(false);
	}
}
