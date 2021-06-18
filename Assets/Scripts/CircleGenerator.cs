using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour, ISquadPositionGentrator
{
    public Vector3[] GetPosition(int count, Vector3 position)
    {
        List<Vector3> pos = new List<Vector3>();

        float oneUnitPositionAngle = 2 * Mathf.PI / count;
        float scale = 3;

        for (int i = 0; i < count; i++)
        {
            pos.Add(new Vector3(position.x + Mathf.Cos(oneUnitPositionAngle * i) * scale,
                position.y, position.z + Mathf.Sin(oneUnitPositionAngle * i) * scale));

        }

        return pos.ToArray();
    }
}
