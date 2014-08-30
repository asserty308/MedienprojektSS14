using UnityEngine;
using System.Collections;

public class ShowScore : MonoBehaviour {

	public string playerName;
	public ScoreTable st;
	private float playerScore;
	private bool savingDone;
	

	// Use this for initialization
	void Start () {
		GameObject gameController = GameObject.Find("GameController");
		PlayerScore scoreKeeper = gameController.GetComponent<PlayerScore>();
		
		if(scoreKeeper){
			int fruitscore = scoreKeeper.score;
			int mult = scoreKeeper.getMuliplier();
			int deaths = scoreKeeper.getDeaths();
			int finalmult = mult - deaths < 0  ? 0 : (mult - deaths);
			playerScore = fruitscore * finalmult;
			
			this.guiText.text = "Multiplier: " + mult + " - " + deaths + " = " + (mult-deaths) + " = " + finalmult +"\n" +
				"Your Score: " + fruitscore + " X " + finalmult + " = " + playerScore;
			
		}else{
			Debug.Log("Score could not be found!");
		}
		
		Destroy(gameController);
		
		savingDone = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI(){
		playerName = GUI.TextField(new Rect (Screen.width/2 - 100f, Screen.height/2 - 200f, 200f, 25f), playerName, 10);
		
		if(!savingDone){
			if(GUI.Button(new Rect (Screen.width/2 - 50f, Screen.height/2 - 150f, 100f, 25f), "Save Score!")){
				PlayerPrefs.SetFloat(playerName, playerScore);
			
				string playerList = PlayerPrefs.GetString("playerList");
				if(!playerList.Contains(playerName)){
					playerList = playerList + playerName + "|";
				}
				PlayerPrefs.SetString("playerList", playerList); 
			
				st.UpdateScore();
				savingDone = true;
			}
		}
	}
}
