using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;

    [SerializeField]
    public bool m_IsSitting;

    float m_RandomWaitTime;
    bool m_IsIdle = true;


    private void Start()
    {
        m_Animator.SetTrigger("moveBackToIdle");
        m_RandomWaitTime = Random.Range(5f, 25f);
    }

    void Update()
    {
        m_Animator.SetBool("Sitting", m_IsSitting);       

        if(m_RandomWaitTime > 0)
        {
            m_RandomWaitTime -= Time.deltaTime;
        }

        if(m_RandomWaitTime <= 0 && m_IsIdle == true)
        {
            //12 different animations -- pick random if at idle state and timer is done
            m_IsIdle = false;
            m_Animator.ResetTrigger("moveBackToIdle");
            int sitState = Random.Range(0, 11);

            m_Animator.SetInteger("SittingState", sitState);
        }

        if(m_Animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1 && m_IsIdle == false)
        {
            m_Animator.SetTrigger("moveBackToIdle");
            m_IsIdle = true;

            m_RandomWaitTime = Random.Range(5f, 25f);
        }
    }
}
