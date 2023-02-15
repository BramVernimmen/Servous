using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    const string m_Tag = "Bottles";

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag(m_Tag))
        {
            Debug.Log("Destroy bottle");
            BottleSpawner.Instance.DestroyedBottle(gameObject);
            Destroy(gameObject);
        }
    }
}
