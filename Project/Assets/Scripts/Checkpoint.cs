using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {

    public PlayerScore playerScore;
	public GameObject respawnable;
	public LayerMask mask;
	public List<scrollscript> backgroundLevels;

    protected Animator m_anim;

	// Use this for initialization
	protected void Start () 
    {
        this.m_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void respawn(){
		playerScore.addDeath();
	
		GameObject newPlayer = (GameObject)Instantiate(respawnable);
		newPlayer.transform.position = this.transform.position;
		newPlayer.layer = LayerMask.NameToLayer("Head");
		
		smooth2Dfollow sm2df = Camera.main.GetComponent<smooth2Dfollow>();
		
		sm2df.target = newPlayer.transform;
		
		scrolltriggerscript scrolltrigger = newPlayer.GetComponent<scrolltriggerscript>();
		scrolltrigger.cam = Camera.main;
		scrolltrigger.playerFollower = sm2df;
		scrolltrigger.backgroundLevels = backgroundLevels;
		
		Head newHead = newPlayer.GetComponent<Head>();
		newHead.successor = null;
		newHead.mask = mask;
		newHead.newSeg = Resources.Load<GameObject>("Segment");
		newHead.grounded = true;

		for(int i = 0; i < 5; i++){
			newHead.growNewSegment();
		}

        playerScore.head = newHead;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Head" || other.tag == "Segment")
        {
            this.m_anim.SetBool("activated", true);
        }
    }
}
