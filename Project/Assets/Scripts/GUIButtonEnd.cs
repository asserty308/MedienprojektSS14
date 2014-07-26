using UnityEngine;
using System.Collections;

public class GUIButtonEnd : MonoBehaviour 
{
    public string m_text;
	private Rect frame;

	// Use this for initialization
	void Start () {
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		frame = new Rect (pos.x, Screen.height - pos.y, 200f, 25f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
    {
		if(GUI.Button(frame, m_text))
        {
			Application.Quit();
		}
	}
}
