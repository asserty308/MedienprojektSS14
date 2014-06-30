using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour 
{
    public GameObject moleActivator;
    public float speedDamp = 0.15f;

    private bool activated;
    private Vector3 moveVector;

	void Start () 
    {
        activated = false;
        moveVector = new Vector3(1f, 0f, 0f);
	}
	
	void Update () 
    {
	    if (activated)
        {
            transform.position += speedDamp * moveVector;
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision MoleActivator");
        if (collider.tag == "Head" || collider.tag == "Segment")
        {
            activated = true;
        }
    }
}
