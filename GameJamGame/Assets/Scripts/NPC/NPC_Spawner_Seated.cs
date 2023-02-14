using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPC_Spawner_Seated : MonoBehaviour
{
    public GameObject m_NPCPrefab;
    Vector3 m_NPCOffset = new Vector3( 0, 0.175f, 0 );

    GameObject m_Spawnednpc;

    void Start()
    {
        //Spawning npc
        m_Spawnednpc = Instantiate(m_NPCPrefab, transform.position + m_NPCOffset, transform.rotation);

        //Setting animation settings
        int animation = UnityEngine.Random.Range(0, 2);
        m_Spawnednpc.GetComponent<NPCBehaviour>().m_SitState = animation;
        m_Spawnednpc.GetComponent<NPCBehaviour>().m_IsSitting = true;


    }

}
