using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 1;
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
        //Root.transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * MovementSpeed;//Input.mousePosition * MovementSpeed;
        Root.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * MovementSpeed, Space.World);
        Root.transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X")) * MovementSpeed, Space.Self);
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
        tempRotX = Mathf.Clamp(tempRotX, -50, 50);
        tempRotY = Mathf.Clamp(tempRotY, -20, 20);
        tempRotZ = Mathf.Clamp(tempRotZ, -50, 50);
        Root.transform.localRotation = Quaternion.Euler(tempRotX, tempRotY, tempRotZ);
    }
}
