using UnityEngine;

[RequireComponent(typeof(AcornWallet))]
public class CollisionDetector : MonoBehaviour
{
    private AcornWallet _acornCollector;

    private void Awake()
    {
        _acornCollector = GetComponent<AcornWallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Acorn>(out Acorn acorn))
        {
            acorn.DisableObject();
            _acornCollector.IncreaseCount();
        }
    }
}
