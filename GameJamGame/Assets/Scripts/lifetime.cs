using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    [SerializeField]
    private float m_LifeTime = 10;

    // Update is called once per frame
    void Update()
    {
        m_LifeTime -= Time.deltaTime;
        if(m_LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
