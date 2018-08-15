using UnityEngine;
using System.Collections;
using ChartAndGraph;

public class StreamingGraph : MonoBehaviour
{

    public GraphChart Graph;
    public int TotalPoints = 5;
    float lastTime = 0f;
    float lastX = 0f;
    //public string label;

    void Start()
    {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        float x = 3f * TotalPoints;
        Graph.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph.DataSource.ClearCategory("data"); // clear the "Player 1" category. this category is defined using the GraphChart inspector

        Graph.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
    }

    public float timeBetweenUpdates = 1f / 10f;
    public transformTracker trackedObject;
    float timeSinceLastUpdate = 0;
    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if(timeSinceLastUpdate > timeBetweenUpdates)
        {
            timeSinceLastUpdate = 0;
            //            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            //Graph.DataSource.AddPointToCategoryRealtime(label, System.DateTime.Now, Random.value * 20f + 10f,0); // each time we call AddPointToCategory 
            //Graph.DataSource.AddPointToCategoryRealtime("Player 2", System.DateTime.Now, Random.value * 10f, 1f); // each time we call AddPointToCategory
            Graph.DataSource.AddPointToCategoryRealtime("data", System.DateTime.Now, trackedObject.getData(), 0); // each time we call AddPointToCategory 
        }

    }
}
