using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private int healAmount = 25;
    [SerializeField] private LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ѕровер€ем, принадлежит ли коллайдер нужному слою
        if ((other.gameObject.layer & playerLayer) != 0)
        {
            Debug.Log("123");
            Health health = other.GetComponent<Health>();
            if (health != null && !health.IsDead)
            {
                health.IncreaseHealth(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
