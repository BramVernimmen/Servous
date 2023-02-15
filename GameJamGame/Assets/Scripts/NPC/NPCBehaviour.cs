using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent m_Agent;

    [SerializeField]
    Animator m_Animator;

    [SerializeField]
    public bool m_IsSitting;

    [SerializeField]
    float m_Speed;

    [SerializeField]
    [Range(0.0f, 2.0f)]
    public int m_SitState;

    float m_RandomWaitTime;
    bool m_IsIdle = true;

    void Update()
    {
        if(m_Agent != null)
        {
            if(m_Agent.velocity.x > 0 || m_Agent.velocity.y > 0)
            {
                m_Speed = 1;
            }
            else
            {
                m_Speed = 0;
            }
        }

        m_Animator.SetBool("Sitting", m_IsSitting);
        m_Animator.SetFloat("Speed", m_Speed);
        m_Animator.SetInteger("SittingState", m_SitState);

        if(m_RandomWaitTime > 0)
        {
            m_RandomWaitTime -= Time.deltaTime;
        }


        if(m_RandomWaitTime <= 0 && m_IsIdle == true)
        {
            //12 different animations -- pick random if at idle state and timer is done
            m_IsIdle = false;
            m_Animator.ResetTrigger("moveBackToIdle");
            int random = Random.Range(0, 12);
            m_SitState = random;
        }

        if(m_Animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1 && m_IsIdle == false)
        {
            m_Animator.SetTrigger("moveBackToIdle");
            m_IsIdle = true;

            m_RandomWaitTime = Random.Range(5, 25);
        }

    }




}
