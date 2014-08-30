using UnityEngine;
using System.Collections;

public class GUIButtonEnd : MonoBehaviour 
{
    public string m_text;
	public Vector2 m_buttonOffset;
	private Rect frame;
	private GUIStyle style;

	// Use this for initialization
	void Start () {
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		frame = new Rect (Screen.width/2 - m_buttonOffset.x, Screen.height - pos.y, 200f, 25f);
		
		Font font = (Font)Resources.Load("Fonts/Cabin_Sketch/CabinSketch-Bold");
		style = new GUIStyle();
		style.font = font;
		style.normal.textColor = Color.blue;
		
		style.fontSize = (int)(0.05 * Mathf.Min(Screen.width, Screen.height));
		
		
		frame = new Rect (Screen.width/2 - m_buttonOffset.x, Screen.height - pos.y, 75f, 25f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Rect newFrame = new Rect(frame);
		newFrame.y = pos.y - 25f;
		
		if(newFrame.Contains(Input.mousePosition)){
			style.normal.textColor = Color.red;
		}else{
			style.normal.textColor = Color.blue;
		}
		
		
	}
	
	void OnGUI()
    {
		if(GUI.Button(frame, m_text, style))
        {
			Application.Quit();
		}
	}
}
