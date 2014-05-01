using UnityEngine;
using System.Collections;

public class GameBorder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D (Collider2D collider)
    {
        //destroy objects falling out of the game
        Destroy(collider.gameObject);
    }
}
