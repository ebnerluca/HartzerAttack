using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float lineLength = 5f;

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, firePoint.position + firePoint.right * lineLength);
    }
}
