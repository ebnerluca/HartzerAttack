using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public Rigidbody2D rb2D;
    public CharacterController2D characterController2D;
    private bool facingRight = true;

    public float flySpeed = 2f;
    public float smoothTime = 0.5f;

    private Vector2 refVelocity = Vector2.zero;
    private float defaultGravity;

    public GameObject eagleSoundEffects;
    public AudioSource eagleScream;

    private void OnEnable()
    {
        defaultGravity = rb2D.gravityScale;
        playerMovement.enabled = false;
        rb2D.gravityScale = 0f;
        facingRight = !characterController2D.m_FacingRight; //ghettofix
        Flip(); //ghettofix
        eagleSoundEffects.SetActive(true);
        eagleScream.Play();
    }

    private void OnDisable()
    {
        playerMovement.enabled = true;
        rb2D.gravityScale = defaultGravity;
        Flip(); //ghettofix
        eagleSoundEffects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(horizontal, vertical).normalized;
        if (move.x > 0f && !facingRight) { Flip(); }
        else if (move.x < 0f && facingRight) { Flip(); }

        rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, move * flySpeed, ref refVelocity, smoothTime);

    }

    private void Flip()
    {
        characterController2D.Flip();
        facingRight = !facingRight;
    }
}
