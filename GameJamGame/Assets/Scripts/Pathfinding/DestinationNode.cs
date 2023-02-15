using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationNode : PathNode
{
    [SerializeField]
    private int m_Difficulty;

    public int Difficulty
    {
        get { return m_Difficulty; }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        PathGraph.Instance.RegisterNode(this);
        PathGraph.Instance.RegisterDestination(this);
    }

    protected override void OnDisable()
    {
        PathGraph.Instance.UnregisterNode(this);
        PathGraph.Instance.UnregisterDestination(this);
    }
}
