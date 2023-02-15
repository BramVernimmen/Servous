using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PathGraph : MonoBehaviour
{
    private List<PathNode> m_PathGraph;
    private List<List<DestinationNode>> m_Destinations;
    // Start is called before the first frame update

    #region SINGLETON
    private static PathGraph m_Instance;
    private static string m_SingletonInstance = "Singleton_PathGraph";
    private static bool m_ApplicationQuitting = false;

    public static PathGraph Instance
    {
        get
        {
            if (m_Instance == null && !m_ApplicationQuitting)
            {
                m_Instance = FindObjectOfType<PathGraph>();
                if (m_Instance == null)
                {
                    GameObject newObject = new GameObject(m_SingletonInstance);
                    m_Instance = newObject.AddComponent<PathGraph>();
                }
            }
            return m_Instance;
        }
    }

    public void OnApplicationQuit()
    {
        m_ApplicationQuitting = true;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else if (m_Instance != this)
        {
            Destroy(gameObject);
        }

        m_PathGraph = new List<PathNode>();
        m_Destinations = new List<List<DestinationNode>>();
        for (int i = 0; i < 5; ++i)
        {
            m_Destinations.Add(new List<DestinationNode>());
        }
    }

    #endregion


    public void RegisterDestination(DestinationNode node)
    {
        if (node)
        {
            m_Destinations[node.Difficulty].Add(node);
        }
    }

    public void UnregisterDestination(DestinationNode node)
    {
        if (node)
        {
            m_Destinations[node.Difficulty].Remove(node);
        }
    }

    public void RegisterNode(PathNode node)
    {
        if (!m_PathGraph.Contains(node))
        {
            m_PathGraph.Add(node);
        }
    }

    public void UnregisterNode(PathNode node)
    {       
        m_PathGraph.Add(node);  
    }

    public Vector3 GetRandomDestinationForDifficulty(int difficulty)
    {
        int rand = Random.Range(0, m_Destinations[difficulty].Count);
        return m_Destinations[difficulty][rand].transform.position;
    }

    public Vector3 GetNextPathPoint(Vector3 currentPos, float acceptanceRadiusSq, Vector3 dest)
    {
        float distToDestSq = (dest - currentPos).sqrMagnitude;
        float closestNodeDistSq = float.MaxValue;
        PathNode currentNode = null;
        foreach(PathNode node in m_PathGraph)
        {        
            float distanceSq = (node.transform.position - currentPos).sqrMagnitude;
            if (distanceSq < closestNodeDistSq)
            {
                currentNode = node;
                closestNodeDistSq = distanceSq;
            }
        }

        if (currentNode == null || distToDestSq < closestNodeDistSq)
        {
            return dest;
        }

        closestNodeDistSq = float.MaxValue;
        PathNode nextNode = null;
        foreach (PathNode node in currentNode.Nodes)
        {
            float distanceSq = (dest - node.transform.position).sqrMagnitude;
            if (distanceSq < closestNodeDistSq)
            {
                nextNode = node;
                closestNodeDistSq = distanceSq;
            }
        }

        if (nextNode == null || distToDestSq <= (nextNode.transform.position - currentPos).sqrMagnitude)
        {
            return dest;
        }

        return nextNode.transform.position;
    }
}
