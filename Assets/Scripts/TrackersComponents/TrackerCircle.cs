﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 2D circle displayed at the feet of the player.
/// </summary>
public class TrackerCircle : MonoBehaviour
{
    /// <summary>
    /// Image of the circle
    /// </summary>
    [SerializeField]
    private Image _circle;
    /// <summary>
    /// Layer of the ground
    /// </summary>
    [SerializeField]
    private LayerMask _ground;

    // Start is called before the first frame update
    void Start()
    {
        _circle.color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);

        StickGround(this.gameObject);
    }

    /// <summary>
    /// Object will position itself on the ground.
    /// </summary>
    private void StickGround(GameObject mesh)
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, 50, _ground))
        {
            mesh.transform.position = new Vector3(mesh.transform.position.x, mesh.transform.position.y, hit.collider.transform.position.z);
        }
    }
}