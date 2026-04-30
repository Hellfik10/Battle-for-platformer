using UnityEngine;

public class NearestTargetDetector : MonoBehaviour
{
    private Collider2D _currentTarget = null;

    public Collider2D GetTarget(float circleRadius, LayerMask layerMask)
    {
        _currentTarget = null;
        float lastDistance = 0;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, circleRadius, layerMask);

        if (hits != null)
        {
            foreach (var hit in hits)
            {
                if (_currentTarget == null)
                {
                    _currentTarget = hit;
                    lastDistance = gameObject.transform.position.SqrDistance(hit.transform.position);
                }

                if (gameObject.transform.position.SqrDistance(hit.transform.position) < lastDistance)
                {
                    _currentTarget = hit;
                    lastDistance = gameObject.transform.position.SqrDistance(hit.transform.position);
                }
            }

            return _currentTarget;
        }

        return null;
    }
}
