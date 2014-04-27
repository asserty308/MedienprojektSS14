using UnityEngine;
using System.Collections;

public class scrollscript : MonoBehaviour {

	public float scrollspeed;
	private Vector2 offset;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		offset = renderer.material.mainTextureOffset;
		
		if(scrollspeed != 0){
			offset += new Vector2((Time.deltaTime * scrollspeed), 0f);
		}
		
		renderer.material.mainTextureOffset = offset;
	
	}
}
