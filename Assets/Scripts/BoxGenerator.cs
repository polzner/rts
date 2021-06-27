using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour, ISquadPositionGentrator
{
    public Vector3[] GetPosition(int count, Vector3 position)
    {
        List<Vector3> pos = new List<Vector3>();
        int rowLenght = (int)Mathf.Sqrt(count);
        int currentVerticalRowSpacing = 2;
        int scale = 2;
        int step = 0;

        for (int i = 0; i < count; i++)
        {
            if(rowLenght == step)
            {
                currentVerticalRowSpacing -= scale;
                step = 0;
            }

            pos.Add(new Vector3(position.x + step*scale, position.y, position.z + currentVerticalRowSpacing));
            step++;
        }

        return pos.ToArray();
    }
}
