using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _flightDuration;

    private Rigidbody2D _body2D;

    private void Awake()
    {
        _body2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       StartCoroutine(TimerBulletDestroyer(_flightDuration));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void MoveBullet(Vector2 direrction)
    {
        _body2D.AddForce(direrction * _speedBullet, ForceMode2D.Impulse);
    }

    private IEnumerator TimerBulletDestroyer(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
