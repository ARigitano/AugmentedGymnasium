using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attacks that targets a randomly chosen player.
/// </summary>
public class BreathOfFire : Attack
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SelectTarget();
        StartCoroutine(Fire());
    }

    /// <summary>
    /// Randomly selects a player.
    /// </summary>
    private void SelectTarget()
    {
        int playerNumber = Random.Range(0, TrackersManager.instance.trackers.Count);
        Transform target = TrackersManager.instance.trackers[playerNumber].transform;
        transform.LookAt(target);
    }

    /// <summary>
    /// Shoots a breath of fire at a player.
    /// </summary>
    /// <returns></returns>
    IEnumerator Fire()
    {
        while (!isReady)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
