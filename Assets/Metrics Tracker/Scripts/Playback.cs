using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using ChartAndGraph;


//drag file in
//press "load"
//loads in all data
//makes gameobject fields for all tracked objects

public class Playback : MonoBehaviour 
{
    public TextAsset sessionDataFile;
    public SessionData loadedData;
    public List<GameObject> linkedObjects;
    public Slider slider;
    public bool properlyLoaded = false;
    public playButton playButton;
    private float elapsedTimeThisPoint = 0.0f;
    List<GraphChart> graphs;

    void Start ()
    {
        graphs = new List<GraphChart>(GameObject.FindObjectsOfType<GraphChart>());
    }
	
	void Update () 
	{
        //startPlaying();
        if(properlyLoaded)
        {
            updatePlayback();
        }
        // startPlaying();
        if(slider.value >= slider.maxValue)
        {
            playButton.playing = false;
        }
	}

    //get objectTracker from json file
    public bool loadJson()
    {
        properlyLoaded = false;
        if(Application.isPlaying)
        {
            Debug.Log("You did it!");

            //deserialize object
            loadedData = JsonConvert.DeserializeObject<SessionData>(sessionDataFile.text);
            //loadedData2 = JsonUtility.FromJson(sessionDataFile.text, typeof(objectData));

            foreach(TrackedObject obj in loadedData.objects)
            {
                Debug.Log(obj.name);
                
            }

            if (loadedData.objects.Count > 0)
            {
                properlyLoaded = true;
            }
            //Load sensor data into graphs

            //get graphs


            if ((loadedData.sensordata != null && loadedData.sensordata.Count > 0) && (graphs != null && graphs.Count > 0))
            {
                for (int i = 0; i < loadedData.sensordata.Count; i++)
                {

                    Debug.Log("Loading data into graph " + i.ToString());
                    //load data into graphs[i]
                    if (loadedData.sensordata[i] != null && graphs[i] != null)
                    {

                        for (int j = 0; j < loadedData.sensordata[i].dataPoints.Count; j++)
                        {
                            Debug.Log(j.ToString());
                            graphs[i].DataSource.AddPointToCategory("Player 1", loadedData.sensordata[i].dataPoints[j].time, loadedData.sensordata[i].dataPoints[j].value);
                        }
                    }
                }
            }
            return true;
        }
        else
        {
            Debug.Log("Load while running the scene");
            return false;
        }
    }

 

    public void startPlaying()
    {
        if (playButton.playing)
            StartCoroutine(play());
        else
            StopCoroutine(play());
    }

    IEnumerator play()
    {
        if (!playButton.playing)
            yield return null;

        while(playButton.playing && slider.value < slider.maxValue)
        {
            yield return new WaitForSeconds(loadedData.objects[0].points[(int)slider.value + 1].time - loadedData.objects[0].points[(int)slider.value].time);
            slider.value++;
        }
    }
    public void updatePlayback()
    {
        //scroll graphs
        for(int i = 0; i < graphs.Count; i++)
        {
            graphs[i].HorizontalScrolling = loadedData.objects[0].points[(int)slider.value].time;
        }

        //update objects
        //Debug.Log(loadedData.objects[0].points[i].time);
        for (int j = 0; j < loadedData.objects.Count; j++)
        {
            if (linkedObjects[j] != null)
            {
                linkedObjects[j].transform.position = loadedData.objects[j].points[(int)slider.value].position;
                linkedObjects[j].transform.rotation = loadedData.objects[j].points[(int)slider.value].rotation;
                //Debug.Log("updated!");
            }
        }

    }
}
