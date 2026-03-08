using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion leftRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion rightRotation = Quaternion.identity;

    public void FlipCharacter(float horizontalDirection)
    {
        if (horizontalDirection < 0)
        {
            transform.rotation = leftRotation;
        }
        else if (horizontalDirection > 0)
        {
            transform.rotation = rightRotation;
        }
    }
}
