using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private GameObject _winPopUp;
    [SerializeField] private GameObject _losePopUp;

    private CoinCollector _collector;
    private CoinsController _coinsController;

    private void Awake()
    {
        _collector = FindObjectOfType<CoinCollector>();
        _coinsController = FindObjectOfType<CoinsController>();
    }

    private void OnEnable()
    {
        _collector.GameOver += OnGameOver;
        _coinsController.WinGame += OnWinGame;
    }

    private void OnDisable()
    {
        _collector.GameOver -= OnGameOver;
        _coinsController.WinGame -= OnWinGame;
    }

    private void OnGameOver()
    {
        _losePopUp.SetActive(true);
    }

    private void OnWinGame()
    {
        _winPopUp.SetActive(true);
    }
}
