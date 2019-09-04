using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A fire tornado that revolves around the dungeon boss.
/// </summary>
public class Tornado : MonoBehaviour
{
    /// <summary>
    /// The fire branches of the tornado.
    /// </summary>
    [SerializeField]
    private Attack[] _attacks;
    /// <summary>
    /// Duration of the tornado.
    /// </summary>
    [SerializeField]
    private float _duration = 10f;
    /// <summary>
    /// Rotation speed of the tornado.
    /// </summary>
    [SerializeField]
    private float _rotationSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TornadoRotation());
    }

    /// <summary>
    /// Makes the tornado rotate around the boss.
    /// </summary>
    /// <returns></returns>
    IEnumerator TornadoRotation()
    {
        while (!_attacks[0].isReady)
        {
            yield return null;
        }

        while (_duration > 0f)
        {
            this.transform.Rotate(0f, 0f, _rotationSpeed);
            _duration -= Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
        
    }
}
