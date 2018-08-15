using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//drag file in
//press "load"
//loads in all data
//makes gameobject fields for all tracked objects

[CustomEditor(typeof(Playback))]
public class PlaybackEditor : Editor
{
    public bool drawFullInspector;
    public override void OnInspectorGUI()
    {
        Playback playbackTarget = (Playback)target;

        //Check for and resolve nulls
        if (playbackTarget.slider == null)
        {
            playbackTarget.slider = GameObject.FindObjectOfType<UnityEngine.UI.Slider>();
            if(playbackTarget.slider == null)
            {
                playbackTarget.slider = EditorGUILayout.ObjectField("Slider", playbackTarget.slider, typeof(UnityEngine.UI.Slider), true) as UnityEngine.UI.Slider;
            }
        }

        if(playbackTarget.playButton == null)
        {
            playbackTarget.playButton = GameObject.FindObjectOfType<playButton>();
            if (playbackTarget.playButton == null)
            {
                playbackTarget.playButton = EditorGUILayout.ObjectField("Play Button", playbackTarget.playButton, typeof(playButton), true) as playButton;
            }
        }


        EditorGUILayout.BeginHorizontal();
        {

            playbackTarget.sessionDataFile = EditorGUILayout.ObjectField("Session Data Path", playbackTarget.sessionDataFile, typeof(TextAsset), true) as TextAsset;

            if (playbackTarget.sessionDataFile != null)
            {
                if (GUILayout.Button("Load", GUILayout.Width(50)))
                {
                    
                    playbackTarget.properlyLoaded = false;
                    if (Application.isPlaying)
                    {
                        playbackTarget.linkedObjects.Clear();
                        if (playbackTarget.loadJson())
                        {
                            playbackTarget.properlyLoaded = true;
                            playbackTarget.slider.maxValue = playbackTarget.loadedData.objects[0].points.Count - 1;
                            foreach (TrackedObject obj in playbackTarget.loadedData.objects)
                            {
                                playbackTarget.linkedObjects.Add(null);
                            }
                        }

                        for (int i = 0; i < playbackTarget.linkedObjects.Count; i++)
                        {
                            playbackTarget.linkedObjects[i] = GameObject.Find(playbackTarget.loadedData.objects[i].name);
                        }
                    }
                }
            }
        }
        EditorGUILayout.EndHorizontal();

        if(playbackTarget.properlyLoaded)
        {
            for(int i = 0; i < playbackTarget.loadedData.objects.Count; i++)
            {
                playbackTarget.linkedObjects[i] = (GameObject)EditorGUILayout.ObjectField(playbackTarget.loadedData.objects[i].name, playbackTarget.linkedObjects[i], typeof(GameObject), true);
            }

            //try to find objects

           
            //if(GUILayout.Button("Play"))
            //{
            //    playbackTarget.play();
            //}

            playbackTarget.updatePlayback();
        }
        drawFullInspector = EditorGUILayout.Foldout(drawFullInspector, "draw full inspector", true);
        if(drawFullInspector)
        {
            DrawDefaultInspector();
        }

    }

    
}
