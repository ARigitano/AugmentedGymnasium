using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script that should be on every ViveTracker
/// </summary>
public class ViveTracker : MonoBehaviour
{
    /// <summary>
    /// Id number of the tracker
    /// </summary>
    public int id; 

    void OnEnable()
    {
        TrackersManager.instance.NewTrackerConnected(gameObject);
        id = TrackersManager.instance.trackers.Count;
        gameObject.name = "Vive Tracker " + id.ToString();
        Debug.Log(gameObject.name+" connected.");
    }

    private void OnDisable()
    {
        Debug.Log(gameObject.name + " disconnected.");
        TrackersManager.instance.TrackerDisconnected(gameObject);
    }
}
