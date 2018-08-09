using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public LocomotionDeviceManager.Devices currentDevice;

    public GameObject teleportingController;
    public LocomotionDeviceManager locomotionController;

    public GameObject pathGroup1, pathGroup2, pathGroup3;
    public GameObject instructionSign1, instructionSign2;
    public GameObject ball, cube;

    public MetricsGatherer metrics;

    // Use this for initialization
    void Start()
    {
        metrics.startTimer("FullRun");

        if(currentDevice == LocomotionDeviceManager.Devices.Teleporting)
        {
            teleportingController.SetActive(true);
            locomotionController.gameObject.SetActive(false);
        }
        else
        {
            //teleportingController.SetActive(false);
            locomotionController.gameObject.SetActive(true);
            locomotionController.initialize(currentDevice);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onBallPickup()
    {
        if (pathGroup1.activeSelf)
        {
            pathGroup1.SetActive(false);
            instructionSign1.SetActive(false);

            pathGroup2.SetActive(true);
            instructionSign2.SetActive(true);
            cube.SetActive(true);
        }

        metrics.startTimer("BallHold");
        metrics.stopTimer("BallDrop");
    }

    public void onBallDetach()
    {
        if(pathGroup2.activeSelf)
        {
            // maybe do something to tell them to pick up the ball again?
        }

        metrics.stopTimer("BallHold");
        metrics.startTimer("BallDrop");
    }

    public void onCubePickup()
    {
        if (pathGroup2.activeSelf)
        {
            pathGroup2.SetActive(false);
            instructionSign2.SetActive(false);

            pathGroup3.SetActive(true);
        }

        metrics.startTimer("CubeHold");
        metrics.stopTimer("CubeDrop");
    }

    public void onCubeDetach()
    {
        if (pathGroup2.activeSelf)
        {
            // maybe do something to tell them to pick up the ball again?
        }

        metrics.startTimer("CubeDrop");
        metrics.stopTimer("CubeHold");
    }
}
