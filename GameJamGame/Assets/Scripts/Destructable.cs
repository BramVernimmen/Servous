using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject m_DestroyedVersion;

    private void OnMouseDown()
    {
        BreakObject();
    }
    public void BreakObject()
    {
        Instantiate(m_DestroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
