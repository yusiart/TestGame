using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    private Ball _ball;

    public event UnityAction GameOver;
    public event UnityAction<Coin> CoinCountChanged; 

    private void Start()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Thotn thotn))
        {
            Destroy(_ball.gameObject);
            GameOver?.Invoke();
        }

        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            CoinCountChanged?.Invoke(coin);
        }
    }
}
