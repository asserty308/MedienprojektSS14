using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	public float fadeSpeed;
	public bool startFading;
	public GameObject audioSource;
	
	private bool fadeMusicOut;
	

	// Use this for initialization
	void Start () {
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		startFading = false;
		fadeMusicOut = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(startFading){
			FadeIn();
		}
		
		if(fadeMusicOut){
			audioSource.audio.volume -= 0.3f * Time.deltaTime;
		}
	}
	
	void FadeIn(){
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	public void Fade(){
		startFading = true;
		fadeMusicOut = true;
	}
	
}
