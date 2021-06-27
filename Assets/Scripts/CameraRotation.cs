using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _scale = 4;
    float time;


    private void Start()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth/2,
                Camera.main.pixelHeight/2, 0)), out RaycastHit hit);
        _target.position = new Vector3(hit.point.x, _target.position.y, hit.point.z);
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            var mouseX = Input.GetAxis("Mouse X");
            Quaternion rotation = Quaternion.AngleAxis(mouseX * _scale, Vector3.up);
            _target.rotation *= rotation;
        } 
    }
}
