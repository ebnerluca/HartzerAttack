using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    public float runSpeed = 40f;

    public CharacterManager characterManager;

    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        characterManager.currentSpeed = Mathf.Abs(horizontalMove);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            characterManager.SetJumping(true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
    }

    public void OnLanding()
    {
        characterManager.SetJumping(false);
    }

    public void OnCrouching(bool isCrouching)
    {
        characterManager.SetCrouching(isCrouching);
    }

    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
