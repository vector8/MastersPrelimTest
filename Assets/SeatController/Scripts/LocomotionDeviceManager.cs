using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionDeviceManager : MonoBehaviour
{
    public enum Devices
    {
        Teleporting,
        ButtController,
        FootPedals,
        Wasd
    }

    private ArduinoComponent arduinoComp;
    private WasdController wasdController;
    private FirstPersonController fpsController;

    private FootPedalController footController;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initialize(Devices currentDevice)
    {
        arduinoComp = GetComponent<ArduinoComponent>();
        wasdController = GetComponent<WasdController>();
        fpsController = GetComponent<FirstPersonController>();
        footController = GetComponent<FootPedalController>();

        arduinoComp.enabled = false;
        wasdController.enabled = false;

        switch (currentDevice)
        {
            case Devices.Teleporting:
                break;
            case Devices.ButtController:
                arduinoComp.enabled = true;
                break;
            case Devices.Wasd:
                wasdController.enabled = true;
                break;
            case Devices.FootPedals:
                footController.enabled = true;
                break;

            default:
                break;
        }

        fpsController.currentDevice = currentDevice;
    }
}
