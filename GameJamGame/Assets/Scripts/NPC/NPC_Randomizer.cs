using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Randomizer : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_ListSkins = new List<GameObject>();

    void Start()
    {
        int random = UnityEngine.Random.Range(0, m_ListSkins.Count);

        for(int i = 0; i < m_ListSkins.Count; i++)
        {
            m_ListSkins[i].SetActive(false);
        }

        m_ListSkins[random].SetActive(true);
    }
}
