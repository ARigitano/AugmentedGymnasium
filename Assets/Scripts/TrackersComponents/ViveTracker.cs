using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script that should be on every ViveTracker
/// </summary>
public class ViveTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("New Vive Tracker connected.");
        TrackersManager.instance.NewTrackerConnected(gameObject);
        //TrackersManager.instance.trackers.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
