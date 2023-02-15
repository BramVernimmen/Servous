using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationNode : MonoBehaviour
{
    [SerializeField]
    private int m_Difficulty;

    public int Difficulty
    {
        get { return m_Difficulty; }
    }

    private void OnEnable()
    {
        //Destination nodes are not added to the graph
        PathGraph.Instance.RegisterDestination(this);
    }

    private void OnDisable()
    {
        PathGraph.Instance.UnregisterDestination(this);
    }
}
