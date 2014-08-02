using UnityEngine;
using System.Collections;

public class MoleActivator : MonoBehaviour 
{
    public Mole mole;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Head")
        {
            mole.setActivated(true);
        }
    }
}
