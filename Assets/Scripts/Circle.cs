using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{

    public int vertexPoints = 10;
    public float radius = 10f;
    private float angleIncrement;

    public LineRenderer line;


    private void Awake()
    {
        angleIncrement = 2*Mathf.PI / (float)vertexPoints;
        line.positionCount = vertexPoints;
    }

    private void OnEnable()
    {
        Update();
        line.enabled = true;
    }

    public void OnDisable()
    {
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(0f, 0f, 0f);

        for(int i = 0; i < vertexPoints; i++)
        {
            position.x = transform.position.x + radius * Mathf.Cos(angleIncrement * i);
            position.y = transform.position.y + radius * Mathf.Sin(angleIncrement * i);
            line.SetPosition(i, position);
        }
    }
}
