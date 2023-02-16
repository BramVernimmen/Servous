using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementBehaviour : MonoBehaviour
{
    private DestinationNode m_CurrentDest = null;
    private DestinationNode m_PlayerNode = null;
    //public Vector3 m_GoalPosition;
    public Vector3 GetGoal()
    {
        if (m_CurrentDest != null)
        {
            return m_CurrentDest.transform.position;
        }
        return Vector3.zero;
    }
    public void SetGoal(DestinationNode node)
    {
        m_CurrentDest = node;
        //print(m_GoalPosition);
        m_ArrivedAtDestination = false;
        SetDestination();
    }

    public NavMeshAgent m_Agent;

    //temp for testing
    public Camera cam;

    [Range(0.0f, 10.0f)] //Setting the speed in inspector with a slider with range 0 - 15
    public float speed = 1.0f;
    private float m_AcceptanceRadius = 0.25f;
    private bool m_ArrivedAtDestination = false;

    private void Start()
    {
        m_Agent.isStopped = false; //Agent start not being able to move
        m_Agent.speed = speed; //Setting the movement speed
        m_PlayerNode = GetComponent<DestinationNode>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Move")) //Enable or dissable the movement of the agent
        {
            m_Agent.isStopped = !m_Agent.isStopped;
        }
        if (HasArrivedAtNode(transform.position, m_Agent.destination))
        {
            if (m_CurrentDest == null) return;
            if (HasArrivedAtNode(transform.position, m_CurrentDest.transform.position) && !m_ArrivedAtDestination)
            {
                Game.Instance.OnDestinationArrival();
                m_ArrivedAtDestination = true;
            }
            else
            {
                SetDestination();
            }
        }
        if (m_ArrivedAtDestination)
        {

        }
    }

    public void ReturnToStart()
    {
        m_CurrentDest = m_PlayerNode;
        m_Agent.SetDestination(m_PlayerNode.transform.position);
    }

    private void SetDestination()
    {
        Vector3 nextNodePos = PathGraph.Instance.GetNextPathPoint(m_Agent.transform.position, m_AcceptanceRadius, m_CurrentDest.transform.position);
        m_Agent.SetDestination(nextNodePos); //Setting the destination   
    }

    public bool hasArrived() //Check if the player has reached the end of the path
    {
        return m_Agent.remainingDistance < speed;
    }


    void tempPositionSetting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast");
                //m_GoalPosition = hit.point;
            }
        }
    }

    private bool HasArrivedAtNode(Vector3 currentPos, Vector3 nodePos)
    {
        float distanceSq = (currentPos - nodePos).sqrMagnitude;
        return distanceSq <= m_AcceptanceRadius;
    }

}
