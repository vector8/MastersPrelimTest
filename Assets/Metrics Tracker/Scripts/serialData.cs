using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class serialData : MonoBehaviour {
    public string lastLine;
	public void OnSerialData(string line)
    {
        lastLine = line;
    }
}
