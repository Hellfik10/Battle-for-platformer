using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action<Item> OnCollected;

    protected void DisableObject()
    {
        OnCollected?.Invoke(this);
    }
}