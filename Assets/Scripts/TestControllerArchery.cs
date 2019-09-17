using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControllerArchery : MonoBehaviour
{
    public static TestControllerArchery instance;

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
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
            return;
        }

        foreach (GameObject obj in teleportingObjs)
        {
            obj.SetActive(currentDevice == LocomotionDeviceManager.Devices.Teleporting);
        }
        locomotionController.initialize(currentDevice);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onBowPickup()
    {
        if (firstTime)
        {
            firstPathGroup.SetActive(false);
            firstTargetGroup.SetActive(true);
            firstTime = false;
        }
    }

    public void onArrowShoot()
    {
        metrics.incrementCounter("ArrowShot");
    }

    public void onFirstTargetHit()
    {
        metrics.incrementCounter("TargetHit");
        metrics.startTimer("FullRun");
        firstTargetGroup.SetActive(false);
        pathGroups[currentGroup].SetActive(true);
    }

    public void onTargetHit()
    {
        metrics.incrementCounter("TargetHit");
        pathGroups[currentGroup].SetActive(false);

        currentGroup++;
        if (currentGroup >= pathGroups.Length)
        {
            // this is the end of the test
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            return;
#else
            Application.Quit();
#endif
        }

        pathGroups[currentGroup].SetActive(true);
    }
}
