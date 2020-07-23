using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public float tentacleRadius = 10f;
    public float pullForce = 30f;
    public LayerMask layerMask;

    public GameObject circleObject;
    public Circle circle;

    public GameObject tentacleObject;
    public LineRenderer tentacleLine;

    private void OnEnable()
    {
        circleObject.SetActive(true);
        circle.radius = tentacleRadius;

        tentacleObject.SetActive(true);
    }

    private void OnDisable()
    {
        circleObject.SetActive(false);
        tentacleObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tentacleLine.SetPosition(0, transform.position);

        Collider2D[] powerUps = Physics2D.OverlapCircleAll(transform.position, tentacleRadius, layerMask);

        foreach(Collider2D powerUp in powerUps)
        {
            Vector2 direction = new Vector2(transform.position.x, transform.position.y) - powerUp.attachedRigidbody.position;
            direction.Normalize();

            powerUp.attachedRigidbody.velocity += direction * pullForce * Time.deltaTime;

            tentacleLine.SetPosition(1, powerUp.attachedRigidbody.position);
        }

        if(powerUps.Length == 0) { tentacleLine.SetPosition(1, transform.position); }
    }
}
