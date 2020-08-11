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

    private List<GameObject> arms = new List<GameObject>();
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public float armThickness = 0.25f;
    public int armCount = 10;
    public Material armMaterial;
    public int sortingOrder = 6;

    private void Awake()
    {
        for(int i = 0; i<armCount; i++)
        {
            GameObject newGameObject = new GameObject();
            newGameObject.name = "Arm";
            newGameObject.transform.parent = gameObject.transform;
            arms.Add(newGameObject);

            LineRenderer lineRenderer = arms[i].AddComponent<LineRenderer>();
            lineRenderer.widthMultiplier = armThickness;
            lineRenderer.material = armMaterial;
            lineRenderer.positionCount = 2;
            lineRenderer.sortingOrder = sortingOrder;
            lineRenderers.Add(lineRenderer);

        }
    }

    private void OnEnable()
    {
        circleObject.SetActive(true);
        circle.radius = tentacleRadius;

        foreach (GameObject arm in arms)
        {
            arm.SetActive(true);
        }

        foreach(LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.enabled = false;
        }

    }

    private void OnDisable()
    {
        circleObject.SetActive(false);

        foreach(GameObject arm in arms)
        {
            arm.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(LineRenderer arm in lineRenderers)
        {
            arm.SetPosition(0, transform.position);
            arm.SetPosition(1, transform.position);
        }

        Collider2D[] powerUps = Physics2D.OverlapCircleAll(transform.position, tentacleRadius, layerMask);

        int i = 0;
        foreach(Collider2D powerUp in powerUps)
        {

            if( i >= lineRenderers.Count) { break; }

            Vector2 direction = new Vector2(transform.position.x, transform.position.y) - powerUp.attachedRigidbody.position;
            direction.Normalize();

            powerUp.attachedRigidbody.velocity += direction * pullForce * Time.deltaTime;

            lineRenderers[i].enabled = true;
            lineRenderers[i].SetPosition(0, powerUp.attachedRigidbody.position);

            i++;
        }

    }
}
