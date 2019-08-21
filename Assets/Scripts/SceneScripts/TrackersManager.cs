using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the trackers in the scene
/// </summary>
public class TrackersManager : MonoBehaviour
{
    public static TrackersManager instance;
    /// <summary>
    /// List of all the trackers in the scene
    /// </summary>
    public List<GameObject> trackers = new List<GameObject>();
    /// <summary>
    /// A new tracker has been connected event
    /// </summary>
    public UnityEvent newTrackerConnected;
    /// <summary>
    /// A tracker has been disconnected event
    /// </summary>
    public UnityEvent trackerDisconnected;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    /// <summary>
    /// Called when a new tracker has been connected
    /// </summary>
    public void NewTrackerConnected(GameObject tracker)
    {
        trackers.Add(tracker);
        newTrackerConnected.Invoke();
    }

    /// <summary>
    /// Called when a tracker has been disconnected
    /// </summary>
    public void TrackerDisconnected(GameObject tracker)
    {
        for(int i = 0; i<trackers.Count; i++)
        {
            if(tracker == trackers[i])
            {
                trackers.RemoveAt(i);
            }
        }

        trackerDisconnected.Invoke();
    }
}
