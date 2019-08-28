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
    private int _nbChairs = 8;
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
    /// Duration of a round in seconds.
    /// </summary>
    [SerializeField]
    private int _roundDuration = 60;
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
    [SerializeField]
    private List<GameObject> _chairs = new List<GameObject>();

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
            ChairsInstantiating();

            for (int j = _waitingTime; j >= 0; j--)
            {
                _status.text = "Round starts in " + j;
                yield return new WaitForSeconds(1f);
            }

            for (int j = _roundDuration; j >= 0; j--)
            {
                _status.text = j + " seconds remaining";
                yield return new WaitForSeconds(1f);
            }

            _nbChairs--;
            _status.text = "End of round";

        if(_nbChairs > 0)
        {
            StartCoroutine(Rounds());
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

        for (int i = 0; i < _nbChairs; i++)
        {
            float angle = i * Mathf.PI * 2f / _nbChairs;
            Vector3 position = new Vector3(Mathf.Cos(angle) * _radius, Mathf.Sin(angle) * _radius, transform.position.y);
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
