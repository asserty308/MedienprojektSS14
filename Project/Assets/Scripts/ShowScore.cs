using UnityEngine;
using System.Collections;

public class ShowScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gameController = GameObject.Find("GameController");
		PlayerScore scoreKeeper = gameController.GetComponent<PlayerScore>();
		
		
		if(scoreKeeper){
			this.guiText.text = "Your score: " + scoreKeeper.score;
		}else{
			Debug.Log("Score could not be found!");
		}
		
		Destroy(gameController);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
