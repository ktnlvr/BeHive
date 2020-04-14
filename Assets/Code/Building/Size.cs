using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    public Vector3 size;
    public Vector3 center;

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + center, size);
        Gizmos.DrawSphere(transform.position + center, 0.03f);
    }
}
