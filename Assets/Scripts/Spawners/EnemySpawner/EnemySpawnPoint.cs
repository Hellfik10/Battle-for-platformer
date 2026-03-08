using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<Transform> _route;

    public void Spawn()
    {
        Enemy enemy = Instantiate(_prefab, transform.position, Quaternion.identity);
        enemy.Init(_route);
    }
}
