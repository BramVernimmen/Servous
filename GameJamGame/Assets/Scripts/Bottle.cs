using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    const string m_Tag = "Bottles";
    bool destroyed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag(m_Tag))
        {
            if(!destroyed)
            {
                Debug.Log("Destroy bottle");
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
            Debug.Log("Destroy bottle on ground");
            BottleSpawner.Instance.DestroyedBottle(gameObject);
            destroyed = true;
            Destroy(gameObject);
        }
    }
}
