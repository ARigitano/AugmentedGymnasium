using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attacks that targets a randomly chosen player.
/// </summary>
public class BreathOfFire : Attack
{

    /// <summary>
    /// Layer of the shield.
    /// </summary>
    [SerializeField]
    private LayerMask _shield;
    /// <summary>
    /// Tarden randomly chosen.
    /// </summary>
    private GameObject target;

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
        target = TrackersManager.instance.trackers[playerNumber]; 
        transform.LookAt(target.transform.position);
    }

    /// <summary>
    /// Checks if the player is protected behind a shield.
    /// </summary>
    private void CheckShield()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, 50, _shield))
        {
            target.GetComponent<TrackerCircle>().isSafe = true;
        }
        else
        {
            target.GetComponent<TrackerCircle>().isSafe = false;
        }
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

    private void Update()
    {
        CheckShield();
    }

}
