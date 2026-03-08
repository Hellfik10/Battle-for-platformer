using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    private List<Transform> _points = new List<Transform>();
    private float _distance = 1.25f;

    private int _currentPointIndex = 0;

    public event Action<Transform> CurrentPointUpdated;

    private void Update()
    {
        if (transform.position.IsEnoughClose(_points[_currentPointIndex].position, _distance))
        {
            _currentPointIndex = (_currentPointIndex + 1) % _points.Count;
            CurrentPointUpdated?.Invoke(_points[_currentPointIndex]);
        }
    }

    public Transform GetFirstPoint()
    {
        return _points.First();
    }

    public void Init(List<Transform> points)
    {
        _points = points;
        CurrentPointUpdated?.Invoke(GetFirstPoint());
    }
}
