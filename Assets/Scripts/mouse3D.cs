using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouse3D : MonoBehaviour,IPointerMoveHandler
{

    private static mouse3D _instance;
    private Vector3 _currentPosition;

    private void Awake()
    {
        _instance = this;
    }

    public static Vector3 GetCurrentWorldPosition() => _instance.GetWorldPosition();
    private Vector3 GetWorldPosition()
    {
        return _currentPosition;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        _currentPosition = eventData.pointerCurrentRaycast.worldPosition;
    }

}