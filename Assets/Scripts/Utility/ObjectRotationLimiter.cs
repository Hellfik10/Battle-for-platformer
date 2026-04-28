using UnityEngine;

public class ObjectRotationLimiter : MonoBehaviour
{
    [SerializeField] private Transform childObject;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;

    void Update()
    {
        float angle = childObject.rotation.eulerAngles.x;

        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        childObject.rotation = Quaternion.Euler(0, angle, 0);
    }
}
