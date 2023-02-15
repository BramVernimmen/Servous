using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pathPos = PathGraph.Instance.GetNextPathPoint(new Vector3(0, 0, 0), 5.0f, new Vector3(0, 0, 50));
        Debug.Log("PathPos x=" + pathPos.x + " y=" + pathPos.y + " z=" + pathPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
