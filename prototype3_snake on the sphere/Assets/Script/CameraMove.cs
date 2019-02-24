using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    const float rotateSpeed = 2f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            RotateCamera();
        }
    }

    void RotateCamera()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.RotateAround(Vector3.zero, -Vector3.up, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed);
        }
    }

}
