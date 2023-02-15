using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    //Fields
    [SerializeField]
    private List<GameObject> m_NodeObjects;
    private List<PathNode> m_Nodes;
    // Start is called before the first frame update

    public List<PathNode> Nodes
    {
        get { return m_Nodes; }
    }

    private void Awake()
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

    private void OnEnable()
    {
        PathGraph.Instance.RegisterNode(this);
    }

    private void OnDisable() 
    { 
        PathGraph.Instance.UnregisterNode(this);
    }
}
