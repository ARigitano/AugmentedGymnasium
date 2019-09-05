using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A meteor from the boss's meteors attack.
/// </summary>
public class Meteor : Attack
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(FallingMeteor());
    }

    /// <summary>
    /// Deals damage when the meteor hits the ground.
    /// </summary>
    /// <returns></returns>
    IEnumerator FallingMeteor()
    {
        while(!isReady)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
