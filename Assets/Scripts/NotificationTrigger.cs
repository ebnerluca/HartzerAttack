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

    public bool ready = true;
    public bool destroyAfterTrigger = false;

    public UnityEngine.Events.UnityEvent stuffToDo;

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

        GameObject.FindGameObjectWithTag("NotificationCenter").GetComponent<NotificationCenter>().ShowNotification(notification);

        stuffToDo.Invoke();

        if (destroyAfterTrigger){
            Destroy(gameObject);
        }else {
            StartCoroutine(Timer(duration));
        }
    }

    IEnumerator Timer(float timer)
    {
        ready = false;

        yield return new WaitForSeconds(timer);

        ready = true;
    }


}
