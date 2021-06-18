using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    private bool _isCollised;

    public bool IsCollised => _isCollised;
    public UnityEvent OnCollised = new UnityEvent();
    public UnityEvent OnFree = new UnityEvent();

    public void OnCollisionStay(Collision collision)
    {
        _isCollised = true;
        OnCollised?.Invoke();
    }

    public void OnCollisionExit(Collision collision)
    {
        _isCollised = false;
        OnFree?.Invoke();
    }
}
