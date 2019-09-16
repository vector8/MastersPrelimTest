using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControllerArchery : MonoBehaviour
{
    public LocomotionDeviceManager.Devices currentDevice;

    public GameObject[] teleportingObjs;
    public LocomotionDeviceManager locomotionController;

    public GameObject firstPathGroup;
    public GameObject firstTargetGroup;

    public GameObject[] pathGroups;

    public MetricsGatherer metrics;

    private int currentGroup = 0;
    private bool firstTime = true;

    private void Awake()
    {
        foreach(GameObject obj in teleportingObjs)
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

    public void onBowPickup()
    {
        if(firstTime)
        {
            firstPathGroup.SetActive(false);
            firstTargetGroup.SetActive(true);
            firstTime = false;
        }
    }

    public void onArrowShot()
    {
        metrics.incrementCounter("ArrowShot");
    }

    public void onFirstTargetHit()
    {
        metrics.incrementCounter("TargetHit");
        firstTargetGroup.SetActive(false);
        pathGroups[currentGroup].SetActive(true);
    }

    public void onTargetHit()
    {
        metrics.incrementCounter("TargetHit");
        pathGroups[currentGroup].SetActive(false);

        currentGroup++;
        if(currentGroup >= pathGroups.Length)
        {
            // this is the end of the test
            Application.Quit();
            return;
        }

        pathGroups[currentGroup].SetActive(true);
    }
}
