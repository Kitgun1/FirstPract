using UnityEngine;

public class TrapMover : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    private void FixedUpdate()
    {
        Mover(_speedRotation);
    }

    private void Mover(float speed)
    {
        float currentRotationZ = transform.rotation.z;
        transform.Rotate(transform.rotation.x, transform.rotation.y, speed);
    }
}