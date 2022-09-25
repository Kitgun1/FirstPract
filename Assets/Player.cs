using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coins = 0;
    [SerializeField] private CoinDisplay _coinDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8) return;

        TakeCoin(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 9) return;

        TryDied();
    }

    private void TakeCoin(Collider2D collision)
    {
        _coins++;
        Destroy(collision.gameObject);
        _coinDisplay.SetCoin(_coins);
    }

    private void TryDied()
    {
        SceneManager.LoadScene(0);
    }
}
