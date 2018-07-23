using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionDeviceManager : MonoBehaviour
{
    public enum Devices
    {
        Teleporting,
        ButtController,
        WiiFit,
        ThreeDRudder
    }

    private ArduinoComponent arduinoComp;
    private WasdController wasdController;

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
        arduinoComp.enabled = false;
        wasdController.enabled = false;

        switch (currentDevice)
        {
            case Devices.Teleporting:
                break;
            case Devices.ButtController:
                arduinoComp.enabled = true;
                break;
            case Devices.WiiFit:
            case Devices.ThreeDRudder:
                wasdController.enabled = true;
                break;
            default:
                break;
        }
    }
}
