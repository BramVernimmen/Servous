using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    //Fields
    [SerializeField]
    protected List<GameObject> m_NodeObjects;
    protected List<PathNode> m_Nodes;

    [SerializeField]
    protected bool m_AddToGraph = true;
    public bool AddToGraph
    {
        get { return m_AddToGraph; }
    }
    // Start is called before the first frame update

    public List<PathNode> Nodes
    {
        get { return m_Nodes; }
    }

    protected virtual void Awake()
    {
        m_Nodes = new List<PathNode>();
        foreach (var nodeObj in m_NodeObjects)
        {
            if (!nodeObj) continue;
            PathNode node = nodeObj.GetComponent<PathNode>();
            if (!node) continue;
            m_Nodes.Add(node);
        }
    }

    protected virtual void OnEnable()
    {
        PathGraph.Instance.RegisterNode(this);
    }

    protected virtual void OnDisable() 
    { 
        PathGraph.Instance.UnregisterNode(this);
    }
}
