using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float turnSpeed = 90f;

    // Use this for initialization
    void Start()
    {
        FirstPersonController fpsController = GetComponent<FirstPersonController>();
        fpsController.m_WalkSpeed = movementSpeed;
        fpsController.turnSpeed = turnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = 0f, horizontal = 0f;
        if(Input.GetKey(KeyCode.W))
        {
            vertical += 1.0f;
        }
        if(Input.GetKey(KeyCode.S))
        {
            vertical -= 1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal += 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= 1.0f;
        }

        CustomInput.SetAxis("Vertical", vertical);
        CustomInput.SetAxis("Horizontal", horizontal);
    }
}
