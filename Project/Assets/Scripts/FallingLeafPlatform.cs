using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FallingLeafPlatform : MonoBehaviour {

	public float t;
	public List<Transform> bezierPoints;
	private Vector2 lastPosition;
	private Vector2[] bezierPointsCoordiates;
	private Vector2[] coordinateCopy; 
	
	
	// Use this for initialization
	void Start () {
		t = 0;
		lastPosition = transform.position;
		
		bezierPointsCoordiates = new Vector2[bezierPoints.Count];
		
		for(int i = 0; i < bezierPoints.Count; i++){
			bezierPointsCoordiates[i] = bezierPoints[i].position;
		}
		
		coordinateCopy = new Vector2[bezierPointsCoordiates.Length]; 
	}
	
	// Update is called once per frame
	void Update () {
		
	    Vector2 position = DeCasteljau(t);
	    transform.position = position;
		
		Vector2 delta = (position - lastPosition); 
		
		rigidbody2D.velocity += delta;
		
		t += Time.deltaTime * 0.0625f;
		
		if(transform.position.y < bezierPointsCoordiates[bezierPointsCoordiates.Length-1].y){
			this.transform.DetachChildren();
			transform.position = bezierPointsCoordiates[0];
			this.transform.eulerAngles = Vector3.zero;
			this.rigidbody2D.angularVelocity = 0f;
			t = 0.0625f;
		}
		
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Head"){
			other.transform.parent = this.transform;
			Head head = other.transform.GetComponent<Head>();
			head.updateParent();
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Head"){
			other.transform.parent = null;
			Head head = other.transform.GetComponent<Head>();
			head.updateParent();
		}
	}
	
	void OnDrawGizmos(){
		
		Gizmos.color = Color.red;
		
		bezierPointsCoordiates = new Vector2[bezierPoints.Count];
		
		for(int i = 0; i < bezierPoints.Count; i++){
			bezierPointsCoordiates[i] = bezierPoints[i].position;
		}
		
		coordinateCopy = new Vector2[bezierPointsCoordiates.Length];
		
		for(int i = 0; i < bezierPointsCoordiates.Length; i++){
			Gizmos.DrawLine(bezierPointsCoordiates[i] + new Vector2(1f, -1f),
			                bezierPointsCoordiates[i] + new Vector2(-1f, 1f));
			
			Gizmos.DrawLine(bezierPointsCoordiates[i] + new Vector2(-1f, -1f),
			                bezierPointsCoordiates[i] + new Vector2(1f, 1f));
		}
		  
		
		Vector2 posA = transform.position;
		Vector2 posB;
		for(float t = 0; t <= 1f; t += 0.0625f){
			posB = DeCasteljau(t);
			Gizmos.DrawLine(posA, posB);
			posA = posB;
		}
	}
	
	Vector2 DeCasteljau(float t){
		
		bezierPointsCoordiates.CopyTo(coordinateCopy, 0);
	
		for(int i = 0; i < bezierPointsCoordiates.Length; i++){
			for(int j = 0; j < bezierPointsCoordiates.Length-i-1; j++){
				coordinateCopy[j] += t*(coordinateCopy[j+1] - coordinateCopy[j]);
			}
		}
		
		return coordinateCopy[0];
		
	}
}
