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

    [Range(0.0f, 15.0f)] //Setting the speed in inspector with a slider with range 0 - 15
    public float speed = 1.0f;


    private void Start()
    {
        m_Agent.isStopped = true; //Agent start not being able to move

        m_Agent.speed = speed; //Setting the movement speed
    }

    private void Update()
    {
        tempPositionSetting(); //temp way of setting a destination

        if (Input.GetButtonDown("Move")) //Enable or dissable the movement of the agent
        {
            m_Agent.isStopped = !m_Agent.isStopped;
        }

        m_Agent.SetDestination(m_GoalPosition); //Setting the destination
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
                m_GoalPosition = hit.point;
            }
        }
    }

}
