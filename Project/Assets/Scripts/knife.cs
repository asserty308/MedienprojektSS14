using UnityEngine;
using System.Collections;

public class knife : MonoBehaviour {
	
	public Vector3 directionVector;
	public float t, interval;
	private float startX;
	
	// Use this for initialization
	void Start () {
		this.startX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += (directionVector * t);
		t += Time.deltaTime * interval;
		Mathf.Clamp(t, 0f, 0.1f);
		
		this.transform.position = new Vector3(startX, transform.position.y, transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "InvisibleBorder"){
			t = 0;
			interval *= -1;
		}
	}
	
}
