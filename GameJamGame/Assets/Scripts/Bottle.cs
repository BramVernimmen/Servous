using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField]
    public GameObject m_DestroyedVersion;

    const string m_Tag = "Bottles";
    bool destroyed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag(m_Tag))
        {
            if(!destroyed)
            {
                BreakObject();

                //Debug.Log("Destroy bottle");
                BottleSpawner.Instance.DestroyedBottle(gameObject);
                destroyed = true;
                Destroy(gameObject);
            }
        }
    }

    public void KillBottle()
    {
        if (!destroyed)
        {
            BreakObject();

            //Debug.Log("Destroy bottle on ground");
            BottleSpawner.Instance.DestroyedBottle(gameObject);
            destroyed = true;
            Destroy(gameObject);
        }
    }

    public void BreakObject()
    {
        GameObject brokenBottle = Instantiate(m_DestroyedVersion, transform.position, transform.rotation);
        brokenBottle.transform.localScale = new Vector3(5, 5, 5);
    }
}
