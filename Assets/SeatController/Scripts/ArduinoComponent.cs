using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoComponent : MonoBehaviour
{
    public float stepCooldown = 0.25f;
    public string port;

    public Transform directionFacing;
    public Transform fallbackDirectionFacing;

    private bool lastStepRight = false;
    private float stepCooldownTimer = 0f;
    private SerialPort sp;

    // Use this for initialization
    void Start()
    {
        sp = new SerialPort(port, 9600);
        sp.Open();
        sp.ReadTimeout = 10;
        stepCooldownTimer = stepCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            string arduinoOutput = sp.ReadLine();
            print(arduinoOutput);
            if ((arduinoOutput[0] == '1' || arduinoOutput[0] == '3') && !lastStepRight)
            {
                lastStepRight = !lastStepRight;
                print("Step right!");
                stepCooldownTimer = 0f;
            }
            else if ((arduinoOutput[0] == '2' || arduinoOutput[0] == '3') && lastStepRight)
            {
                lastStepRight = !lastStepRight;
                print("Step left!");
                stepCooldownTimer = 0f;
            }
        }
        catch(System.Exception)
        {
        }

        if (stepCooldownTimer < stepCooldown)
        {
            stepCooldownTimer += Time.deltaTime;
            if (stepCooldownTimer >= stepCooldown)
            {

                CustomInput.SetAxis("Vertical", 0);
                CustomInput.SetAxis("Horizontal", 0);
            }
            else
            {
                Vector3 direction = Vector3.ProjectOnPlane(-1f * directionFacing.forward, Vector3.up);
                CustomInput.SetAxis("Vertical", direction.z);
                CustomInput.SetAxis("Horizontal", direction.x);
            }
        }
    }

    private void OnApplicationQuit()
    {
        sp.Close();
    }
}