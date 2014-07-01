using UnityEngine;
using System.Collections;

public class MoleActivator : MonoBehaviour 
{
    public Mole mole;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision MoleActivator");
        if (collider.tag == "Head" || collider.tag == "Segment")
        {
            mole.setActivated(true);
        }
    }
}
