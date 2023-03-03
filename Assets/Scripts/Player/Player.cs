using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] _hearts;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Disappear();
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            LoseHeart();
        }
    }

    private void LoseHeart()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (_hearts[i] != null)
            {
                Destroy(_hearts[i]);
                break;
            }
        }
    }
}