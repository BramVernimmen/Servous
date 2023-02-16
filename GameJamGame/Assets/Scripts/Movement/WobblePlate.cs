using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WobblePlate : MonoBehaviour
{
    [SerializeField] GameObject m_Plate = null;
    private Vector3 m_MousePos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        m_MousePos = Input.mousePosition;
        //Debug.Log(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Plate != null)
        {
            if (Time.timeScale == 1)
            {

                var xRot = m_Plate.transform.rotation.eulerAngles.x;
                var yRot = m_Plate.transform.rotation.eulerAngles.y;
                var zRot = m_Plate.transform.rotation.eulerAngles.z;

                //Debug.Log(xRot + ", " + yRot + ", " + zRot);
                //Debug.Log(Input.mousePosition.x + ", " + Input.mousePosition.y);
                if ((Mathf.Abs(Input.mousePosition.x - m_MousePos.x) <= 10.0f || Mathf.Abs(Input.mousePosition.y - m_MousePos.y) <= 10.0f) || ((Mathf.Abs(xRot) < 20.0f || Mathf.Abs(xRot) > 340.0f) && (Mathf.Abs(zRot) < 20.0f || Mathf.Abs(zRot) > 340.0f)) )
                {
                    if (Input.mousePosition.x <= Screen.width / 2.0f)
                    {
                        m_Plate.transform.Rotate(Vector3.forward, -0.05f);

                    }
                    else
                    {
                        m_Plate.transform.Rotate(Vector3.forward, 0.05f);

                    }
                }


            }


        }
    }
    

}
