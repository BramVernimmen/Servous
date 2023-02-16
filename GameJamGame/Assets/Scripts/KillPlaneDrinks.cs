using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class KillPlaneDrinks : MonoBehaviour
{
    const string m_Tag = "Bottles";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(m_Tag))
        {
            if(other.isTrigger)
                other.gameObject.GetComponent<Bottle>().KillBottle();
            else
                other.gameObject.GetComponentInParent<Bottle>().KillBottle();
        }
    }
}
