using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour, ISquadPositionGentrator
{
    public static CircleGenerator Instance { get; private set; }

    private float _distance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetDistance(float distance)
    {
        _distance = distance;
    }

    public Vector3[] GetPosition(int count, Vector3 position)
    {
        List<Vector3> pos = new List<Vector3>();

        float oneUnitPositionAngle = 2 * Mathf.PI / count;

        for (int i = 0; i < count; i++)
        {
            pos.Add(new Vector3(position.x + Mathf.Cos(oneUnitPositionAngle * i) * _distance,
                position.y, position.z + Mathf.Sin(oneUnitPositionAngle * i) * _distance));
        }

        return pos.ToArray();
    }
}
