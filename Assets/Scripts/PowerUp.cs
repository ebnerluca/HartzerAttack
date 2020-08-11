using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public virtual void PickUp()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickUp();
    }
}
