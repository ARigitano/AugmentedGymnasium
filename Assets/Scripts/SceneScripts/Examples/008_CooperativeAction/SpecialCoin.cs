using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A coin that gives score to every player.
/// </summary>
public class SpecialCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerArea" && other.GetComponent<TrackerCircle>().isAlive)
        {
            foreach(GameObject player in TrackersManager.instance.trackers)
            {
                player.GetComponent<TrackerCircle>().score++;
            }

            Destroy(gameObject);
        }
    }
}
