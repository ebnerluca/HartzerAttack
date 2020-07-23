using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Hawk : Enemy
{
    public float bounceForce = 10f; //force on player when he jumps on enemy
    public float headJumpBonus = 15f;

    private AIDestinationSetter aiDestinationSetter;
    private AIPath aiPath;

    //public GameObject deathEffect;

    public Hawk()
    {
        health = 100f;
        damage = 20f;
    }

    private void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
    }

    private void Start()
    {
        //InvokeRepeating("FindPlayer", 0f, 1f);
        FindPlayer();
    }

    private void FindPlayer()
    {
        if(aiDestinationSetter.target == null)
        {
            aiDestinationSetter.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01) { transform.localScale = new Vector3(-1f, 1f, 1f); }
        else if (aiPath.desiredVelocity.x <= 0.01) { transform.localScale = new Vector3(1f, 1f, 1f); }
    }

    //override public void TakeDamage(float damage, string reason)
    //{
    //    //Debug.Log("Enemy got hit by " + reason);
    //    health -= damage;

    //    if(health <= 0)
    //    {
    //        Die(); 
    //    }
    //}

    //override public void Die()
    //{
    //    //Instantioate(deathEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f); //set y velocity to zero
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bounceForce), ForceMode2D.Impulse);
            collision.GetComponent<PlayerStats>().IncreaseSpecial(headJumpBonus);

            TakeDamage(200f, "jumped on head");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }

    override public IEnumerator ParalyzeTimer(float duration)
    {
        Hawk hawk = GetComponent<Hawk>();
        AIPath aiPath = GetComponent<AIPath>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        hawk.enabled = false;
        aiPath.canMove = false;
        rb.gravityScale = 1f;
        isParalyzed = true;

        yield return new WaitForSeconds(duration);

        hawk.enabled = true;
        aiPath.canMove = true;
        rb.gravityScale = 0f;
        isParalyzed = false;

    }


}
