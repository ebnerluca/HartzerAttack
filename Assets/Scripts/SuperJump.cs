using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float superJumpMultiplier;
    private float defaultJumpForce;

    private void OnEnable()
    {
        defaultJumpForce = GetComponentInParent<CharacterController2D>().m_JumpForce;
        GetComponentInParent<CharacterController2D>().m_JumpForce *= superJumpMultiplier;
    }

    private void OnDisable()
    {
        GetComponentInParent<CharacterController2D>().m_JumpForce = defaultJumpForce;
    }
}
