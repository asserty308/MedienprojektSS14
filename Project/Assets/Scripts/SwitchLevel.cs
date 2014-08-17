using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public string level;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Head")
        {
            GameObject gameController = GameObject.Find("GameController");
            PlayerScore score = gameController.GetComponent<PlayerScore>();
            int tmpMultiplier = score.getMuliplier();

			Destroy(this.gameObject);
			
			other.rigidbody2D.velocity = Vector3.zero;
			other.rigidbody2D.gravityScale = 0.0f;
			
			Head head = other.GetComponent<Head>();
			head.controlLock = true;
			head.destroyAllSegments();
			
			Animator anim = other.gameObject.GetComponent<Animator>();
			anim.SetBool("ReachedEndOfLevel", true);
			
			Camera.main.orthographicSize = 3.0f;
			smooth2Dfollow sm2Df = Camera.main.GetComponent<smooth2Dfollow>();
			sm2Df.targetPosOnScreenX = 0.5f;
			sm2Df.targetPosOnScreenY = 0.5f;

            score.setMultiplier(tmpMultiplier);
		}
	}
}
