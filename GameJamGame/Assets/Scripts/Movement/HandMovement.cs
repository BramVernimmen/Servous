using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField] private float limit = 0;
    [SerializeField] float Sensitivity = 1;
    GameObject Root;
    // Start is called before the first frame update
    void Start()
    {
        Root = transform.Find("Root").gameObject.transform.Find("PlateRoot").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float xInput = -Input.GetAxis("Mouse Y") * Sensitivity;
        float yInput = Input.GetAxis("Mouse X") * Sensitivity;
        var previousRotation = Root.transform.localRotation;
        var rotation = Root.transform.localRotation;
        rotation *= Quaternion.Euler(xInput, 0.0f, yInput);
        Root.transform.localRotation = rotation; 
        float tempRotY = Root.transform.eulerAngles.y;
        if (tempRotY > 180)
        {
            tempRotY -= 360;
        }
        tempRotY = Mathf.Clamp(tempRotY, -2, 2);
        Root.transform.localRotation = Quaternion.Euler(Root.transform.eulerAngles.x, tempRotY, Root.transform.eulerAngles.z);
        if (Vector3.Dot(Root.transform.up * -1, Vector3.down) < limit)
            Root.transform.localRotation = previousRotation;


        /*
        //Root.transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * Sensitivity;//Input.mousePosition * Sensitivity;
        Root.transform.Rotate(new Vector3(, 0, 0) * Sensitivity, Space.World);
        Root.transform.Rotate(new Vector3(0, 0, ) * Sensitivity, Space.Self);
        float tempRotX = Root.transform.eulerAngles.x;
        float tempRotY = Root.transform.eulerAngles.y;
        float tempRotZ = Root.transform.eulerAngles.z;
        if (tempRotX > 180)
        {
            tempRotX -= 360;
        }
        if (tempRotY > 180)
        {
            tempRotY -= 360;
        }
        if (tempRotZ > 180)
        {
            tempRotZ -= 360;
        }
        */
    }
}
