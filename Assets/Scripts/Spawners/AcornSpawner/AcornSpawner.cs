using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    [SerializeField] private Acorn _prefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        CreateObject(_prefab);
    }

    private void CreateObject(Acorn prefab)
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            var currentObject = Instantiate(prefab, _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    private void DestroyObject(Item item)
    {
        Destroy(item.gameObject);
    }
}
