using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationTrigger : MonoBehaviour
{
    public string type = "none";
    public string title = "none";
    public string description = "none";
    public float duration = 7f;
    public Sprite sprite;

    public GameObject[] hints;
    public GameObject nextStep;

    public bool ready = true;
    public bool destroyAfterTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player") { return; }
        if (!ready) { return; }

        Notification notification = new Notification();
        notification.type = type;
        notification.title = title;
        notification.description = description;
        notification.duration = duration;
        notification.sprite = sprite;

        GameObject.FindGameObjectWithTag("NotificationCenter").GetComponent<NotificationCenter>().ShowNotification(notification);

        //nextStep.SetActive(true);

        if (destroyAfterTrigger){
            Destroy(gameObject);
        }else {
            StartCoroutine(Timer(duration));
        }
    }

    IEnumerator Timer(float timer)
    {
        ready = false;
        foreach(GameObject hint in hints)
        {
            hint.SetActive(true);
        }

        yield return new WaitForSeconds(timer);

        ready = true;
        foreach(GameObject hint in hints)
        {
            hint.SetActive(false);
        }
    }


}
