using UnityEngine;
using System.Collections;

public class GUIButtonRepeat : MonoBehaviour 
{
    public string m_text;
	private Rect frame;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		frame = new Rect (pos.x, Screen.height - pos.y, 200f, 25f);
	}
	
	void OnGUI(){
		if(GUI.Button(frame, m_text)){
			Application.LoadLevel("Main");
		}
	}
}
