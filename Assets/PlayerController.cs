using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _multiplySprint;

    [SerializeField] private GameObject _bullet;

    private Rigidbody2D _body2D;

    private void Start()
    {
        _body2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement(GetDirection());
    }

    private void Update()
    {
        TryShoot();
    }

    private Vector2 GetDirection()
    {
        Vector2 directionMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speedMovement;
        return directionMove;
    }

    private void Movement(Vector2 direction)
    {

        if (Input.GetKey(KeyCode.LeftShift))
            direction *= _multiplySprint;

        _body2D.velocity = direction;
    }

    private void TryShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPosition = transform.position;
            Vector2 direction = mouseWorldPosition - playerPosition;
            direction = direction.normalized;
            var bullet = Instantiate(_bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.MoveBullet(direction);
        }
    }
}
