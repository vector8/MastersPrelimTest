using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformTracker : MonoBehaviour 
{
    public enum trackingMode
    {
        positionX,
        positionY,
        positionZ,
        eulerX,
        eulerY,
        eulerZ
    }

    public trackingMode currentMode;

    public float getData()
    {
        float data = -1;
        switch(currentMode)
        {
            case trackingMode.positionX:
                return gameObject.transform.position.x;
                

            case trackingMode.positionY:
                return gameObject.transform.position.y;

            case trackingMode.positionZ:
                return gameObject.transform.position.z;

            case trackingMode.eulerX:
                return gameObject.transform.rotation.eulerAngles.x;

            case trackingMode.eulerY:
                return gameObject.transform.rotation.eulerAngles.y;

            case trackingMode.eulerZ:
                return gameObject.transform.rotation.eulerAngles.z;
        }
        return data;
    }
}
