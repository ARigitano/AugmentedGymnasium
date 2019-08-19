using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackersManager : MonoBehaviour
{
    #region Slingleton

    public static TrackersManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    #endregion

    public List<GameObject> trackers = new List<GameObject>();
    public UnityEvent newTrackerConnected;
    public UnityEvent trackerDisconnected;

    public void NewTrackerConnected(GameObject tracker)
    {
        trackers.Add(tracker);
        newTrackerConnected.Invoke();
    }

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
