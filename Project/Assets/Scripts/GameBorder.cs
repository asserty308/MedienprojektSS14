using UnityEngine;
using System.Collections;

public class GameBorder : MonoBehaviour {

	void OnTriggerExit2D (Collider2D other) {
        Destroy(other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
