using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISquadPositionGentrator
{
    Vector3[] GetPosition(int count, Vector3 position);
}
