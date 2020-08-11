using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public string welcomeNotificationType;
    public string welcomeNotificationTitle;
    public string welcomeNotificationDescription;
    public float welcomeNotificationScale = 2f;
    public float welcomeNotificationDuration = 10f;
    public float welcomeNotificationDelay = 4f;
    public Sprite welcomeNotificationSprite;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Start()
    {
        playerMovement.enabled = false;

        Notification notification = new Notification();
        notification.title = welcomeNotificationTitle;
        notification.type = welcomeNotificationType;
        notification.description = welcomeNotificationDescription;
        notification.scale = welcomeNotificationScale;
        notification.duration = welcomeNotificationDuration;
        notification.sprite = welcomeNotificationSprite;

        StartCoroutine(ShowNotification(welcomeNotificationDelay, notification));
    }

    private IEnumerator ShowNotification(float delay, Notification notification)
    {
        yield return new WaitForSeconds(delay);
        GameObject.FindGameObjectWithTag("NotificationCenter").GetComponent<NotificationCenter>().ShowNotification(notification);
        yield return new WaitForSeconds(5f);
        playerMovement.enabled = true;
    }
    
}
