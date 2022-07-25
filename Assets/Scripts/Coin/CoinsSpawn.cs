using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _coinsCount;

    private List<Transform> _spawnPoints;
    private Coin[] _coins;
    private CoinsController _coinsController;

    private void Awake()
    {
        _spawnPoints = new List<Transform>();
        
        foreach (Transform child in transform) 
        {
            _spawnPoints.Add(child);
        }
        
        
        _coins = new Coin [_coinsCount];
        _coinsController = FindObjectOfType<CoinsController>();
    }

    private void Start()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        for (int i = 0; i < _coinsCount; i++)
        {
            int randomPos = Random.Range(0, _spawnPoints.Count);
            var coin = Instantiate(_coin, _spawnPoints[randomPos].transform.position, _spawnPoints[randomPos].transform.rotation ).GetComponent<Coin>();
            _spawnPoints.Remove(_spawnPoints[randomPos]);
            _coins[i] = coin;
        }
        
        _coinsController.SetCoins(_coins);
    }
}
