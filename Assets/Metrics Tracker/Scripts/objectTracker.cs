using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

public class objectTracker : MonoBehaviour
{
    public bool logControllerEvents;
    public bool recordSessionMicrophoneAudio;
    public List<trackedObject> trackedObjects;
    public List<trackedDataSource> trackedDataSources;
    public List<trackedControllerEvent> trackedControllerEvents;
    public List<timer> timers;
    private SessionData data;

    void Start()
    {
        trackedObject[] objects = GameObject.FindObjectsOfType<trackedObject>();
        foreach (trackedObject obj in objects)
        {
            trackedObjects.Add(obj);
        }
        if (logControllerEvents)
        {
            this.gameObject.AddComponent<controllerTracker>();
        }

        if (recordSessionMicrophoneAudio)
        {
            this.gameObject.AddComponent<microphoneRecorder>();
        }

       
        timers = new List<timer>();
    }

    private void OnApplicationQuit()
    {
        write();
    }

    public void write()
    {
        List<TrackedObject> objectDataList = new List<TrackedObject>();
        List<trackedData> sensorDataList = new List<trackedData>();
        foreach (trackedObject obj in trackedObjects)
        {
            objectDataList.Add(obj.getDataForOutput());
        }

        foreach (trackedDataSource dataSource in trackedDataSources)
        {
            sensorDataList.Add(dataSource.getDataForExport());
        }

        Debug.Log("Object Data List Size: " + objectDataList.Count);

        SessionData sessionData = new SessionData(objectDataList, sensorDataList, trackedControllerEvents);

        string jsonString = JsonConvert.SerializeObject(sessionData, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });


        StreamWriter writer = new StreamWriter("Assets/" + sessionData.datetime + ".json", false);
        writer.Write(jsonString);
        writer.Close();
    }

    private void FixedUpdate()
    {

    }

    //add timer
    public void addTimer(string _name, float _time)
    {
        timers.Add(new timer(_name, _time));
    }

}
