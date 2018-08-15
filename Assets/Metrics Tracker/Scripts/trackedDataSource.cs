using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//This class isn't meant to be used
//Create a child of this class with its own implementation of filter() to grab the relevant data from the raw data. 
public class trackedDataSource : MonoBehaviour
{
    protected serialData dataSource;
    protected string rawData;
    [SerializeField]
    protected float cleanData;
    private List<trackedDataPoint> dataPoints;
    public string sourceName;
    private void FixedUpdate()
    {
        dataPoints.Add(new trackedDataPoint(Time.time, cleanData));
    }


    void Start()
    {
        dataPoints = new List<trackedDataPoint>();
        dataSource = GameObject.FindObjectOfType<serialData>();
        if (dataSource == null)
        {
            Debug.LogError("Couldn't locate serial data source.");
        }
        sourceName = gameObject.name;
    }


    void Update()
    {
        filter();
 //       Debug.Log(cleanData);
    }

    protected virtual void filter()
    {
        //OVERRIDE THIS FUNCTION IN YOUR IMPLEMENTATION
    }

    public trackedData getDataForExport()
    {
        return new trackedData(gameObject.name, dataPoints);
    }

    public float getData()
    {
        return cleanData;
    }
}
