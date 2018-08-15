using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public LocomotionDeviceManager.Devices currentDevice;

    public GameObject[] teleportingObjs;
    public LocomotionDeviceManager locomotionController;

    public GameObject pathGroup1, pathGroup2, pathGroup3;
    public GameObject instructionSign1, instructionSign2;
    public GameObject ball, cube;

    public MetricsGatherer metrics;
    public objectTracker tracker;

    void Awake()
    {
        foreach (GameObject obj in teleportingObjs)
        {
            obj.SetActive(currentDevice == LocomotionDeviceManager.Devices.Teleporting);
        }
        locomotionController.initialize(currentDevice);
    }

    // Use this for initialization
    void Start()
    {
        metrics.startTimer("FullRun");
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
        if (pathGroup2.activeSelf)
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
