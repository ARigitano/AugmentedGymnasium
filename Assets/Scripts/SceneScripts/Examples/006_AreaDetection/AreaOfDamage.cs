using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A large area of damages centered on the boss.
/// </summary>
public class AreaOfDamage : Attack
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Explosion());
    }

    /// <summary>
    /// The area explodes when the attack is built.
    /// </summary>
    /// <returns></returns>
    IEnumerator Explosion()
    {
        while (!isReady)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
