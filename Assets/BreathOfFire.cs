using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathOfFire : Attack
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SelectTarget();
        StartCoroutine(Fire());
    }

    private void SelectTarget()
    {
        int playerNumber = Random.Range(0, TrackersManager.instance.trackers.Count);
        Transform target = TrackersManager.instance.trackers[playerNumber].transform;
        transform.LookAt(target);
    }

    IEnumerator Fire()
    {
        while (!isReady)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
