using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// Duration of a break between attacks.
    /// </summary>
    [SerializeField]
    private float _break = 10f;
    /// <summary>
    /// Life points of the boss.
    /// </summary>
    public int life = 5000;
    /// <summary>
    /// Displays the life points of the boss.
    /// </summary>
    [SerializeField]
    private Text _scoreText;
    /// <summary>
    /// What attacks can the boss use?
    /// </summary>
    [SerializeField]
    private bool _hasMeteors, _hasAreaOfDamage, _hasTornado, _hasBreathOfFire;

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

    /// <summary>
    /// Cycles through the attacks.
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackPattern()
    {
        while(true)
        {
            yield return new WaitForSeconds(_break);

            if (_hasMeteors)
            {
                Meteors();
                yield return new WaitForSeconds(_break);
            }

            if (_hasAreaOfDamage)
            {
                AreaOfDamage();
                yield return new WaitForSeconds(_break);
            }

            if(_hasTornado)
            {
                Tornado();
                yield return new WaitForSeconds(_break);
            }


            if (_hasBreathOfFire)
            {
                BreathOfFire();
                yield return new WaitForSeconds(_break);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackPattern());
    }

    private void Update()
    {
        if (life <= 0)
            Destroy(gameObject);

        _scoreText.text = life.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerArea")
        {
            life--;
        }
    }
}
