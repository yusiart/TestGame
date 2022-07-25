using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinsController : MonoBehaviour
{
   [SerializeField] private TMP_Text _coinsCount;
   
   private List<Coin> _coins;
   private CoinCollector _collector;
   private int _coinCounter;
   
   public event UnityAction WinGame;

   private void Awake()
   {
      _coins = new List<Coin>();
      _collector = FindObjectOfType<CoinCollector>();
      _coinsCount.text = _coinCounter.ToString();
   }

   private void OnEnable()
   {
      _collector.CoinCountChanged += OnCoinsCountChanged;
   }

   private void OnDisable()
   {
      _collector.CoinCountChanged -= OnCoinsCountChanged;
   }

   public void SetCoins(Coin [] coins)
   {
      foreach (var coin in coins)
      {
         _coins.Add(coin);
      }
   }

   private void OnCoinsCountChanged(Coin current)
   {
      if (current == null)
         return;

      _coins.Remove(current);
      current.DestroyCoin();
      _coinCounter++;
      _coinsCount.text = _coinCounter.ToString();

      if (CheckIsLastCoin())
      {
         WinGame?.Invoke();
      }
   }

   private bool CheckIsLastCoin()
   {
      if (_coins.Count > 0)
      {
         return false;
      }
      else
      {
         return true;
      }
   }
}
