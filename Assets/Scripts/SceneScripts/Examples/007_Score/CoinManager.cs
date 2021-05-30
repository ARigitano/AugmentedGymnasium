using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates showers of coins for the scoring scene.
/// </summary>
public class CoinManager : MonoBehaviour
{
    /// <summary>
    /// Extremities of the coin manager area of influence.
    /// </summary>
    [SerializeField]
    private GameObject _topLeft, _topRight, _bottomLeft, _bottomRight;
    /// <summary>
    /// Prefab of a coin.
    /// </summary>
    [SerializeField]
    private GameObject _coinPrefab;
    /// <summary>
    /// Duration of a break between coin showers.
    /// </summary>
    [SerializeField]
    private float _break = 10f;
    /// <summary>
    /// Number of showers of coins.
    /// </summary>
    [SerializeField]
    private int nbRounds = 10;

    /// <summary>
    /// Generates one shower of coins.
    /// </summary>
    private void CoinsShower()
    {
        int numberCoins = Random.Range(10, 30);

        for (int i = 0; i < numberCoins; i++)
        {
            float coinX = Random.Range(_topLeft.transform.position.x, _topRight.transform.position.x);
            float coinY = Random.Range(_bottomLeft.transform.position.y, _topLeft.transform.position.y);
            float coinZ = this.transform.position.z;

            Instantiate(_coinPrefab, new Vector3(coinX, coinY, coinZ), Quaternion.identity);
        }
    }

    /// <summary>
    /// Creates showers of coins for each round.
    /// </summary>
    /// <returns></returns>
    IEnumerator FallOfCoins()
    {
        while (nbRounds>0)
        {
            CoinsShower();
            nbRounds--;
            yield return new WaitForSeconds(_break);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FallOfCoins());
    }
}
