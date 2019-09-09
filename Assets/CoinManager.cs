using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void CoinsShower()
    {
        int numbeCoins = Random.Range(10, 30);

        for (int i = 0; i < numbeCoins; i++)
        {
            float coinX = Random.Range(_topLeft.transform.position.x, _topRight.transform.position.x);
            float coinY = Random.Range(_bottomLeft.transform.position.y, _topLeft.transform.position.y);
            float coinZ = this.transform.position.z;

            Instantiate(_coinPrefab, new Vector3(coinX, coinY, coinZ), Quaternion.identity);
        }
    }

    IEnumerator FallOfCoins()
    {
        while (true)
        {
            CoinsShower();
            yield return new WaitForSeconds(_break);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FallOfCoins());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
