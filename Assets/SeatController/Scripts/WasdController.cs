using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float turnSpeed = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = 0f, horizontal = 0f;
        if(Input.GetKey(KeyCode.W))
        {
            vertical += movementSpeed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            vertical -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal += turnSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= turnSpeed;
        }

        CustomInput.SetAxis("Vertical", vertical);
        CustomInput.SetAxis("Horizontal", horizontal);
    }
}
