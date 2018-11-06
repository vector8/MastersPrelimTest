using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsGatherer : MonoBehaviour
{
    public string outputDirectory;
    public string savefilePrefix;
    public string subjectName;
    public string deviceName;

    // Number of samples to take per second
    public float granularity = 1.0f;

    public Transform[] positionsToTrack;
    public Transform[] orientationsToTrack;

    private Dictionary<string, uint> counters = new Dictionary<string, uint>();
    private Dictionary<string, float> timers = new Dictionary<string, float>();
    private List<string> activeTimerKeys = new List<string>();

    private float samplingTimer = 0f;

    // for tracking vec3s, need:
    // key (string), Vector3, timestamp (float)
    // vector3 and timestamp stored in a list
    // one list per object tracked, along with key
    private struct TrackedVector3Entry
    {
        public Vector3 vec3;
        public float timestamp;
    }

    private Dictionary<string, List<TrackedVector3Entry>> trackedVec3Lists = new Dictionary<string, List<TrackedVector3Entry>>();
    private Dictionary<string, Transform> trackedPositions = new Dictionary<string, Transform>();
    private Dictionary<string, Transform> trackedOrientations = new Dictionary<string, Transform>();

    // Use this for initialization
    void Start()
    {
        foreach (Transform t in positionsToTrack)
        {
            string key = t.gameObject.name + "Pos" + t.gameObject.GetInstanceID();
            trackedPositions[key] = t;
        }

        foreach (Transform t in orientationsToTrack)
        {
            string key = t.gameObject.name + "Ori" + t.gameObject.GetInstanceID();
            trackedOrientations[key] = t;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string key in activeTimerKeys)
        {
            if(!timers.ContainsKey(key))
            {
                timers[key] = 0;
            }

            timers[key] += Time.deltaTime;
        }

        samplingTimer += Time.deltaTime;

        if (samplingTimer > (1f / granularity))
        {
            samplingTimer = 0f;

            float currentTime = Time.time;

            foreach (string key in trackedPositions.Keys)
            {
                TrackedVector3Entry entry;
                entry.vec3 = trackedPositions[key].position;
                entry.timestamp = currentTime;

                if (!trackedVec3Lists.ContainsKey(key))
                {
                    trackedVec3Lists[key] = new List<TrackedVector3Entry>();
                }

                trackedVec3Lists[key].Add(entry);
            }

            foreach (string key in trackedOrientations.Keys)
            {
                TrackedVector3Entry entry;
                entry.vec3 = trackedOrientations[key].rotation.eulerAngles;
                entry.timestamp = currentTime;

                if (!trackedVec3Lists.ContainsKey(key))
                {
                    trackedVec3Lists[key] = new List<TrackedVector3Entry>();
                }

                trackedVec3Lists[key].Add(entry);
            }
        }
    }

    public void startTimer(string key)
    {
        if (!activeTimerKeys.Contains(key))
        {
            activeTimerKeys.Add(key);
        }
    }

    public void stopTimer(string key)
    {
        activeTimerKeys.Remove(key);
    }

    // Track the position of an object with transform T, using an optional key.
    // If no key is provided, a default one will be generated.
    public void trackObjectPosition(Transform t, string key = null)
    {
        if (key == null)
        {
            key = t.gameObject.name + "Pos" + t.gameObject.GetInstanceID();
        }

        trackedPositions[key] = t;
    }

    // Track the orientation of an object with transform T, using an optional key.
    // If no key is provided, a default one will be generated.
    public void trackObjectOrientation(Transform t, string key = null)
    {
        if (key == null)
        {
            key = t.gameObject.name + "Ori" + t.gameObject.GetInstanceID();
        }

        trackedOrientations[key] = t;
    }

    public void incrementCounter(string key, uint value = 1)
    {
        if (!counters.ContainsKey(key))
        {
            counters[key] = 0;
        }

        counters[key] += value; 
    }

    public void decrementCounter(string key, uint value = 1)
    {
        if (!counters.ContainsKey(key) || counters[key] == 0)
        {
            counters[key] = 0;
            return;
        }

        counters[key] -= value;
    }

    private void OnApplicationQuit()
    {
        // write all metrics to file
        string filename = subjectName + "_" + deviceName + "_" + savefilePrefix + System.DateTime.Now.ToString("yyyyMMddHHmmss");
        string output = "timers:\n";
        foreach(string k in timers.Keys)
        {
            output += k + ":" + timers[k] + "\n";
        }

        output += "counters:\n";
        foreach(string k in counters.Keys)
        {
            output += k + ":" + counters[k] + "\n";
        }

        output += "vec3:\n";
        foreach (string k in trackedVec3Lists.Keys)
        {
            output += k + ":";

            List<TrackedVector3Entry> list = trackedVec3Lists[k];

            foreach(TrackedVector3Entry e in list)
            {
                output += e.timestamp + "," + e.vec3.x + "," + e.vec3.y + "," + e.vec3.z + ";";
            }

            output += "\n";
        }

        System.IO.Directory.CreateDirectory(outputDirectory);
        System.IO.File.WriteAllText(outputDirectory + filename, output);
    }
}
