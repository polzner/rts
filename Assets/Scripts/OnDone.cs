using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDone : MonoBehaviour
{
    private void Start()
    {
        GetComponent<BuildingProduction>().OnDone += (element) =>
        {
            var offset = Random.insideUnitCircle.normalized * (GetComponent<MeshRenderer>().bounds.size.magnitude/2);
            Instantiate(element.Prefab, new Vector3(transform.position.x + offset.x, transform.position.y,
                transform.position.z + offset.y), Quaternion.identity);
        };
    }
}
