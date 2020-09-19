using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroScream : MonoBehaviour
{
    public float startRadius;
    public float endRadius;
    public float duration;
    public float paralyzeDuration = 5f;

    public GameObject shockwaveObject;
    private Circle shockwave;
    public float shockwaveDelay = 0.5f;

    private float deltaRadius;

    private void Awake()
    {
        deltaRadius = (endRadius - startRadius) / duration;
        shockwave = shockwaveObject.GetComponent<Circle>();
    }

    private void OnEnable()
    {
        AudioManager.instance.Play("Bre_Schrei");
        StartCoroutine(Delay(shockwaveDelay));
        //shockwave = shockwaveObject.GetComponent<Circle>();
        //shockwave.radius = startRadius;
        //shockwaveObject.SetActive(true);
    }

    private void OnDisable()
    {
        shockwaveObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shockwave.radius += deltaRadius * Time.deltaTime;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, shockwave.radius);
        foreach(Collider2D collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().Paralyze(paralyzeDuration);
            }
        }
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        shockwave = shockwaveObject.GetComponent<Circle>();
        shockwave.radius = startRadius;
        shockwaveObject.SetActive(true);
    }
}
