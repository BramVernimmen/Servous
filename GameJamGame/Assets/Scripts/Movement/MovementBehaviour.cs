using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementBehaviour : MonoBehaviour
{
    public Vector3 m_GoalPosition;
    public Vector3 GetGoal()
    {
        return m_GoalPosition;
    }
    public void SetGoal(Vector3 goalPosition)
    {
        m_GoalPosition = goalPosition;
    }

    public NavMeshAgent m_Agent;

    //temp for testing
    public Camera cam;

    [Range(0.0f, 10000.0f)] //Setting the speed in inspector with a slider with range 0 - 15
    public float speed = 1.0f;


    private void Start()
    {
        m_Agent.isStopped = false; //Agent start not being able to move

        m_Agent.speed = speed; //Setting the movement speed
    }

    private void Update()
    {
        Vector3 nextNodePos = PathGraph.Instance.GetPathPosition(m_Agent.transform.position, 5.0f, m_GoalPosition);

        tempPositionSetting(); //temp way of setting a destination

        if (Input.GetButtonDown("Move")) //Enable or dissable the movement of the agent
        {
            m_Agent.isStopped = !m_Agent.isStopped;
        }

        print(nextNodePos);
        print(m_GoalPosition);

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
                m_GoalPosition = hit.point;
            }
        }
    }

}
