using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public Transform gun;

    private bool facingRight = true;

    void Update()
    {
        Vector2 shootingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(Mathf.Abs(angle) > 90 && facingRight)
        {
            FlipGun();
            facingRight = false;
        } else if(Mathf.Abs(angle) < 90f && !facingRight)
        {
            FlipGun();
            facingRight = true;
        }
    }

    void FlipGun()
    {
        Vector3 tempScale = gun.localScale;
        tempScale[1] *= -1;
        gun.localScale = tempScale;

        Vector3 tempPosition = gun.localPosition;
        tempPosition[1] *= -1;
        gun.localPosition = tempPosition;
    }
}
