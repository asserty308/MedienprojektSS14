using UnityEngine;
using System.Collections;

public class LeafActivator : MonoBehaviour 
{
    public FallingLeafPlatform m_firstLeaf, m_secondLeaf;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Head")
        {
            m_firstLeaf.activate();
            m_secondLeaf.activate();
        }
    }
}
