using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//This class isn't meant to be used
//Create a child of this class with its own implementation of filter() to grab the relevant data from the raw data. 
public class sensorData : MonoBehaviour
{

    protected serialData dataSource;
    protected string rawData;
    [SerializeField]
    protected string cleanData;
    void Start()
    {
        dataSource = GameObject.FindObjectOfType<serialData>();
        if (dataSource == null)
        {
            Debug.LogError("Couldn't locate serial data source.");
        }
    }


    void Update()
    {
        filter();
        Debug.Log(cleanData);
    }

    protected virtual void filter()
    {
        //OVERRIDE THIS FUNCTION IN YOUR IMPLEMENTATION
    }
}
