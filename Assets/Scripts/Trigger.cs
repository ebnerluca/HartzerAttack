using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent triggerEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEvent.Invoke();
    }
}
