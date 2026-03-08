using UnityEngine;

public class AcornWallet : MonoBehaviour
{
    private int _count = 0;

    public void IncreaseCount()
    {
        _count++;
        Debug.Log(_count);
    }
}
