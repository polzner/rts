using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectUnits : MonoBehaviour
{
    [SerializeField] private Transform _selectionAreaTransform;
    [SerializeField] private BoxGenerator _boxGenerator;
    [SerializeField] private CircleGenerator _circleGenerator;

    public static SelectUnits Instance { get; private set; } 
    private Vector3 _startPosition;
    private List<Unit> _selectedUnits = new List<Unit>();

    private void Awake()
    {
        Instance = this;
        _selectionAreaTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DeselectAllUnits();
            _startPosition = mouse3D.GetCurrentWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            _selectionAreaTransform.gameObject.SetActive(true);
            DrawSquare();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _selectionAreaTransform.gameObject.SetActive(false);
            Vector3 lowerLeft = GetLowerLeftAngleCoordinate();
            Vector3 upperRight = GetUpperRightAngleCoordinate();
            float centerX = lowerLeft.x + (upperRight.x - lowerLeft.x) / 2;
            float centerZ = lowerLeft.z + (upperRight.z - lowerLeft.z) / 2;
            Vector3 selectionCenterPosition = new Vector3(centerX, 0, centerZ);
            float diagonalX = upperRight.x - lowerLeft.x;
            float diagonalZ = upperRight.z - lowerLeft.z;
            Vector3 halfExtents = new Vector3(diagonalX/2, 1,
                diagonalZ/2);
            Collider[] units = Physics.OverlapBox(selectionCenterPosition, halfExtents);

            foreach (var item in units)
            {
                if (item.transform.TryGetComponent(out Unit unit))
                {
                    unit.Selected(true);
                    _selectedUnits.Add(unit);
                }
            }
        }                     
    }

    public void SetCirclePosition(Vector3 point, float distance)
    {
        _circleGenerator.SetDistance(distance);
        Vector3[] pos = _circleGenerator.GetPosition(_selectedUnits.Count,point);

        for (int i = 0; i < pos.Length; i++)
        {
            _selectedUnits[i].SetDestination(pos[i]);
        }
    }

    public void SetBoxPosition(Vector3 point)
    {
        Vector3[] pos = _boxGenerator.GetPosition(_selectedUnits.Count, point);

        for (int i = 0; i < pos.Length; i++)
        {
            _selectedUnits[i].SetDestination(pos[i]);
        }
    }

    public static void MoveUnits(Vector3 point) => Instance.Move(point);

    private void Move(Vector3 position)
    {
        foreach (var unit in _selectedUnits)
        {
            unit.SetDestination(position);
        }
    }

    private Vector3 GetLowerLeftAngleCoordinate()
    {
        Vector3 currentPos = mouse3D.GetCurrentWorldPosition();
        Vector3 leftLower = new Vector3(Mathf.Min(_startPosition.x, currentPos.x), 0.3f, Mathf.Min(_startPosition.z, currentPos.z));
        return leftLower;
    }

    private Vector3 GetUpperRightAngleCoordinate()
    {
        Vector3 currentPos = mouse3D.GetCurrentWorldPosition();
        Vector3 rightUpper = new Vector3(Mathf.Max(_startPosition.x, currentPos.x), 0.3f, Mathf.Max(_startPosition.z, currentPos.z));
        return rightUpper;
    }

    private void DrawSquare()
    {
        Vector3 lowerLeft = GetLowerLeftAngleCoordinate();
        Vector3 upperRight = GetUpperRightAngleCoordinate();
        _selectionAreaTransform.localPosition = new Vector3(lowerLeft.x, 0.3f, lowerLeft.z);
        Vector3 difference = upperRight - lowerLeft;
        _selectionAreaTransform.localScale = new Vector3(difference.x * 100, difference.z * 100, 1);
    }

    private void DeselectAllUnits()
    {
        foreach (var unit in _selectedUnits)
        {
            unit.Selected(false);
        }

        _selectedUnits.Clear();
    }
}
