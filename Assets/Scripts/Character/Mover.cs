using System.Data;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction, float speed)
    {
        Rigidbody.linearVelocityX = direction.x * speed;
    }

    public void Jump(float jumpForce)
    {
        Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
