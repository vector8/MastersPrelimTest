using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButton : MonoBehaviour 
{
    public bool playing = false;
    private Playback playback;

    private void Start()
    {
        playback = GameObject.FindObjectOfType<Playback>();
    }
    public void pressed()
    {
        playing = !playing;
        Debug.Log("Play button pressed!");
        playback.startPlaying();
    }
}
