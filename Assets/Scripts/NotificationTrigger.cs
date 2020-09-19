using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationTrigger : MonoBehaviour
{
    public string type = "none";
    public string title = "none";
    public string description = "none";
    public float scale = 1;
    public float duration = 7f;
    public Sprite sprite;
    public bool disableMovement = false;
    public float disableMovementTimer = 0f;

    public bool ready = true;
    public bool destroyAfterTrigger = false;

    public UnityEngine.Events.UnityEvent stuffToDo;
    public UnityEngine.Events.UnityEvent stuffToDoAfter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player") { return; }
        if (!ready) { return; }

        Notification notification = new Notification();
        notification.type = type;
        notification.title = title;
        notification.description = description;
        notification.scale = scale;
        notification.duration = duration;
        notification.sprite = sprite;
        notification.disableMovement = disableMovement;
        notification.disableMovementTimer = disableMovementTimer;

        GameObject.FindGameObjectWithTag("NotificationCenter").GetComponent<NotificationCenter>().ShowNotification(notification);

        StartCoroutine(Timer(duration));       
    }

    IEnumerator Timer(float timer)
    {
        ready = false;
        stuffToDo.Invoke();

        yield return new WaitForSeconds(timer);

        if (destroyAfterTrigger)
        {
            Destroy(gameObject);
        }

        ready = true;
        stuffToDoAfter.Invoke();
    }


}
