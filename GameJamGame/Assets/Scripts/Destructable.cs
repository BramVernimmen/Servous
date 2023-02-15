using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject m_DestroyedVersion;

    //private void OnMouseDown()
    //{
    //    BreakObject();
    //}
    public void BreakObject()
    {
        GameObject brokenBottle = Instantiate(m_DestroyedVersion, transform.position, transform.rotation);
        brokenBottle.transform.localScale = transform.localScale;

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float velocityBreakpoint = 3.5f;

        if(collision.relativeVelocity.y > velocityBreakpoint)
        {
            BreakObject();
        }
    }
}
