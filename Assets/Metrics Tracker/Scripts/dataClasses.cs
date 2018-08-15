using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class trackedDataPoint
{
    public float time;
    public float value;

    public trackedDataPoint(float _time, float _value)
    {
        time = _time;
        value = _value;
    }
};

[Serializable]
public class trackedData
{
    public string name;
    public List<trackedDataPoint> dataPoints;

    public trackedData(string _name, List<trackedDataPoint> _dataPoints)
    {
        name = _name;
        dataPoints = _dataPoints;
    }

    public void add(float _data)
    {
        //new trackedDataPoint(Time.time, cleanData)
        dataPoints.Add(new trackedDataPoint(Time.time, _data));
    }
}

public enum eventType
{
    touchpadTouch,
    touchpadTouchRelease,
    touchpadPress,
    touchpadPressRelease,
    triggerPress,
    triggerRelease,
    gripPress,
    gripRelease,
    menuPress,
    menuRelease
}

public enum hand
{
    left, right
}

[Serializable]
public class trackedControllerEvent
{
    public trackedControllerEvent(hand _hand, eventType _type)
    {
        time = Time.time;
        hand = _hand;
        type = _type;
    }
    public float time;
    [JsonConverter(typeof(StringEnumConverter))]
    public hand hand;
    [JsonConverter(typeof(StringEnumConverter))]
    public eventType type; //"grab", "release", 
}

[Serializable]
public class timer
{
    public string name;
    public float time;
    public timer(string _name, float _time)
    {
        name = _name;
        time = _time;
    }
}