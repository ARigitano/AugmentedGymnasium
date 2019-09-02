using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A simple musical chairs game.
/// </summary>
public class MusicalChairs : MonoBehaviour
{
    /// <summary>
    /// The number of chairs to be spawned.
    /// </summary>
    private int _nbChairs;
    /// <summary>
    /// Prefab of a chair.
    /// </summary>
    [SerializeField]
    private GameObject _chairPrefab;
    /// <summary>
    /// Radius of the circle of chairs.
    /// </summary>
    [SerializeField]
    private float _radius = 5f;
    /// <summary>
    /// Layer of the ground.
    /// </summary>
    [SerializeField]
    private LayerMask _ground;
    /// <summary>
    /// Minimum duration of a round in seconds.
    /// </summary>
    [SerializeField]
    private int _roundDurationMin = 1;
    /// <summary>
    /// Maximum duration of a round in seconds.
    /// </summary>
    [SerializeField]
    private int _roundDurationMax = 2;
    /// <summary>
    /// The players.
    /// </summary>
    private List<GameObject> _players;
    /// <summary>
    /// Text displaying current status of the game.
    /// </summary>
    [SerializeField]
    private Text _status;
    /// <summary>
    /// Waiting delay between each round.
    /// </summary>
    [SerializeField]
    private int _waitingTime = 10;
    /// <summary>
    /// List of chairs.
    /// </summary>
    [SerializeField]
    private List<GameObject> _chairs = new List<GameObject>();
    /// <summary>
    /// Intance of musical chairs for singleton.
    /// </summary>
    public static MusicalChairs instance;
    /// <summary>
    /// Number of occupied chairs.
    /// </summary>
    public int safeChairs = 0;
    /// <summary>
    /// Are the players allowed to sit?
    /// </summary>
    public bool canSit = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    /// <summary>
    /// Launching the game.
    /// </summary>
    public void GameStart()
    {
        _players = TrackersManager.instance.trackers;
        _nbChairs = _players.Count - 1;
        StartCoroutine(Rounds());
    }

    /// <summary>
    /// Manages the rounds.
    /// </summary>
    /// <returns></returns>
    IEnumerator Rounds()
    {
        int roundDuration = Random.Range(_roundDurationMin, _roundDurationMax);

        //Waiting for beginning of round.
        for (int j = _waitingTime; j >= 0; j--)
        {
            _status.text = "Round starts in " + j;
            yield return new WaitForSeconds(1f);
        }

        ChairsInstantiating();

        //Turning around chairs.
        for (int j = roundDuration; j >= 0; j--)
        {
            _status.text = "";
            yield return new WaitForSeconds(1f);
        }

        _status.text = "SIT!";
        canSit = true;

        //Sitting as quickly as possible.
        while (safeChairs < _nbChairs)
        {
            yield return new WaitForSeconds(0.1f);
        }

        canSit = false;

        //Disqualifying the unsitted player.
        for(int j = 0; j<_players.Count; j++)
        {
            if (!_players[j].GetComponent<TrackerCircle>().isSafe)
            {
                _players[j].SetActive(false);
                break;
            }
        }

        //Resetting the round.
        _nbChairs--;
        _status.text = "End of round";
        safeChairs = 0;

        foreach(GameObject player in _players)
        {
            player.GetComponent<TrackerCircle>().isSafe = false;
        }

        //Restarting the round or ending the game.
        if(_nbChairs > 0)
        {
            StartCoroutine(Rounds());
        }
        else
        {
            _status.text = " Winner: " + _players[0].name;
        }
    }

    /// <summary>
    /// Spawns the right number of chairs in a circle.
    /// </summary>
    private void ChairsInstantiating()
    {
        if(_chairs != null)
        {
            foreach(GameObject chair in _chairs)
            {
                Destroy(chair);
            }

            _chairs.Clear();
        }
        if (_nbChairs > 1)
        {
            for (int i = 0; i < _nbChairs; i++)
            {
                float angle = i * Mathf.PI * 2f / _nbChairs;
                Vector3 position = new Vector3(Mathf.Cos(angle) * _radius, Mathf.Sin(angle) * _radius, transform.position.y);
                GameObject chair = Instantiate(_chairPrefab, position, Quaternion.identity);
                StickGround(chair);
                _chairs.Add(chair);
            }
        }
        else
        {
            Vector3 position = transform.position;
            GameObject chair = Instantiate(_chairPrefab, position, Quaternion.identity);
            StickGround(chair);
            _chairs.Add(chair);
        }
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
