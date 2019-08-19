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

    //public delegate void OnNewTrackerConnected();
    //public OnNewTrackerConnected onNewTrackerConnectedCallback;

    public UnityEvent newTrackerConnected; 

    public void NewTrackerConnected(GameObject tracker)
    {
        trackers.Add(tracker);
        newTrackerConnected.Invoke();

        //if (onNewTrackerConnectedCallback != null)
        //    onNewTrackerConnectedCallback.Invoke();
    }
}
