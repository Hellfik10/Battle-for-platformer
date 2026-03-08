using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader))]
public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float HorizontalDirection { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction, float speed)
    {
        _rigidbody.velocity = new Vector2(speed * direction, _rigidbody.velocity.y);
    }

    public void Move(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public void Jump(float jumpForce)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    public void SetDirection(float direction)
    {
        HorizontalDirection = direction;
    }

    public void ResetDirection()
    {
        HorizontalDirection = 0;
    }

    public float GetVerticalVelocity()
    {
        return _rigidbody.velocity.y;
    }
}