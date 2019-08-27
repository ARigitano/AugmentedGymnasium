using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerInitialization : MonoBehaviour
{
    public ViveTracker[] trackers;

    void Awake()
    {
        trackers = GameObject.FindObjectsOfType<ViveTracker>();
    }

    public void Initialization(string newText)
    {
        int number = int.Parse(newText);

        if(number <= trackers.Length)
        {
            for(int i = 0; i<number; i++)
            {
                trackers[i].gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Number too big");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
