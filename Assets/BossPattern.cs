using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the attack patterns for a dungeon boss.
/// </summary>
public class BossPattern : MonoBehaviour
{
    /// <summary>
    /// Extremities of the boss' area of influence.
    /// </summary>
    [SerializeField]
    private GameObject _topLeft, _topRight, _bottomLeft, _bottomRight;
    /// <summary>
    /// Prefabs for the attack areas of damage.
    /// </summary>
    [SerializeField]
    private GameObject _meteorPrefab, _areaPrefab, _tornadoPrefab, _breathPrefab;
    /// <summary>
    /// A zone in which the players are safe from the boss' damages.
    /// </summary>
    [SerializeField]
    private GameObject _safeZonePrefab;

    /// <summary>
    /// An attack that makes meteors fall from the sky in random locations.
    /// </summary>
    private void Meteors()
    {
        int numberMeteors = Random.Range(3, 10);

        for(int i=0; i < numberMeteors; i++)
        {
            float meteorX = Random.Range(_topLeft.transform.position.x, _topRight.transform.position.x);
            float meteorY = Random.Range(_bottomLeft.transform.position.y, _topLeft.transform.position.y);
            float meteorZ = this.transform.position.z;

            Instantiate(_meteorPrefab, new Vector3(meteorX, meteorY, meteorZ), Quaternion.identity);
        }
    }

    /// <summary>
    /// An attack that deals damage in a large area all around the boss.
    /// </summary>
    private void AreaOfDamage()
    {
        Instantiate(_areaPrefab, this.transform.position, Quaternion.identity);

        float safeZoneX = Random.Range(_topLeft.transform.position.x, _topRight.transform.position.x);
        float safeZoneY = Random.Range(_bottomLeft.transform.position.y, _topLeft.transform.position.y);
        float safeZoneZ = this.transform.position.z;

        Instantiate(_safeZonePrefab, new Vector3(safeZoneX, safeZoneY, safeZoneZ), Quaternion.identity);
    }

    /// <summary>
    /// An attack that creates a rotating tornado centered on the boss' position.
    /// </summary>
    private void Tornado()
    {
        Instantiate(_tornadoPrefab, this.transform.position, Quaternion.identity);
    }

    /// <summary>
    /// An attack that spawns a line of fire directed at a player chosen randomly.
    /// </summary>
    private void BreathOfFire()
    {
        int playerNumber = Random.Range(0, TrackersManager.instance.trackers.Count);
        Transform target = TrackersManager.instance.trackers[playerNumber].transform;

        GameObject breath = (GameObject)Instantiate(_breathPrefab, this.transform.position, Quaternion.identity);

        breath.transform.LookAt(target);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Meteors();
        //AreaOfDamage();
        //Tornado();
        BreathOfFire();
    }
}
