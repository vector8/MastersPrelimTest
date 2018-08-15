using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microphoneRecorder : MonoBehaviour {

    public int maxRecordingLength = 300;//length of microphone clips in seconds, 
    private AudioClip recording;
	void Start ()
    {
        //from: https://stackoverflow.com/questions/49622517/how-to-record-audio-on-button-press-hold-and-play-the-recorded-audio-on-button-r
        //Get the max frequency of a microphone, if it's less than 44100 record at the max frequency, else record at 44100
        int minFreq;
        int maxFreq;
        int freq = 44100;
        Microphone.GetDeviceCaps("", out minFreq, out maxFreq);
        if (maxFreq < 44100)
            freq = maxFreq;

        recording = Microphone.Start("", false, maxRecordingLength, freq);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnApplicationQuit()
    {
        Microphone.End("");
        SavWav.Save(System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"), recording);
    }
}
