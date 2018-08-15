using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackedObject : MonoBehaviour
{
    private TrackedObject tracked;
    private void Start()
    {
        tracked = new TrackedObject(gameObject.name);
    }
    private void FixedUpdate()
    {
        tracked.addPoint(Time.time, gameObject.transform.position, gameObject.transform.rotation);
    }

    public TrackedObject getDataForOutput()
    {
        return tracked;
    }
}


