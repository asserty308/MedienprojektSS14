using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public string level;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Head"){
			Application.LoadLevel(level);
		}
	}
}
