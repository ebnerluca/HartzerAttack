using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 100;
    public float damage = 20f;
    public bool isParalyzed = false;

    virtual public void TakeDamage(float damage, string reason)
    {
        health -= damage;

        if (health <= 0) { Die(); }
    }

    public void Paralyze(float duration)
    {
        StartCoroutine(ParalyzeTimer(duration));
    }

    virtual public IEnumerator ParalyzeTimer(float duration)
    {
        Enemy enemy = GetComponent<Enemy>();

        enemy.enabled = false;
        isParalyzed = true;
        yield return new WaitForSeconds(duration);
        enemy.enabled = true;
        isParalyzed = false;
    }

    virtual public void Die()
    {
        Destroy(gameObject);
    }
}
