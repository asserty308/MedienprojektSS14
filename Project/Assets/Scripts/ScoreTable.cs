using UnityEngine;
using System.Collections;

public class ScoreTable : MonoBehaviour {

	Vector3 pos;
	Rect frame;
	string playerList;
	string[] playerListArray;

	// Use this for initialization
	void Start () {
		pos = Camera.main.WorldToScreenPoint(transform.position);
		frame = new Rect (pos.x, Screen.height - pos.y, 600f, 600f);
		
		UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void UpdateScore(){
		playerList = PlayerPrefs.GetString("playerList");
		char[] seperator = {'|'};
		playerListArray = playerList.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries);
		quicksort(0, playerListArray.Length-1);
	}
	
	void OnGUI(){
		
		GUILayout.BeginArea(frame);
	
		GUILayout.BeginHorizontal();
		
		GUILayout.BeginVertical();
		for(int i = 0; i < 10; i++){
			if(i < playerListArray.Length){
				GUILayout.Label(playerListArray[i]);
			}else{
				GUILayout.Label("...");
			}		
		}
		GUILayout.EndVertical();
		
		GUILayout.BeginVertical();
		for(int i = 0; i < 10; i++){
			if(i < playerListArray.Length){
				GUILayout.Label(PlayerPrefs.GetFloat(playerListArray[i]) + "");	
			}else{
				GUILayout.Label("...");
			}
		}
		GUILayout.EndVertical();
		
		GUILayout.EndHorizontal();
		
		GUILayout.EndArea();
	}
	
	
		
	
	
	void quicksort(int left, int right){
		if(left < right){
			int part = partition(left, right);
			quicksort(left, part-1);
			quicksort(part+1, right); 
		}	
	}
	
	int partition(int left, int right){
		int i = left;
		int j = right - 1;
		int pivot = right;
		
		do{
		
			while(PlayerPrefs.GetFloat(playerListArray[i]) >= PlayerPrefs.GetFloat(playerListArray[pivot]) && i < right){
				i++;
			}
			
			while(PlayerPrefs.GetFloat(playerListArray[j]) <= PlayerPrefs.GetFloat(playerListArray[pivot]) && j > left){
				j--;
			}
			
			if(i < j){
				string temp = playerListArray[i];
				playerListArray[i] = playerListArray[j];
				playerListArray[j] = temp;
			}
		
		}while(i < j);
		
		if(PlayerPrefs.GetFloat(playerListArray[i]) < PlayerPrefs.GetFloat(playerListArray[pivot])){
			string temp = playerListArray[pivot];
			playerListArray[pivot] = playerListArray[i];
			playerListArray[i] = temp;
		}
		
		return i;	
	}
}
