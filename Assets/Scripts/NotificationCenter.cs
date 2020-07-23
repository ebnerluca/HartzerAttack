using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationCenter : MonoBehaviour
{
    public Image background;
    public Sprite notificationSprite;
    public TextMeshProUGUI notificationTitle;
    public TextMeshProUGUI notificationText;
    public float notificationDuration = 5f;

    public GameObject[] children;

    private void Start()
    {
        ToggleVisible();
    }

    public void ShowNotification(Notification notification)
    {
        //notificationSprite = notification.sprite;
        notificationTitle.text = notification.title;
        notificationText.text = notification.text;

        StartCoroutine(NotificationTimer(notification.duration));
    }

    IEnumerator NotificationTimer(float notificationDuration)
    {
        //gameObject.SetActive(true);
        ToggleVisible();
        yield return new WaitForSeconds(notificationDuration);
        ToggleVisible();
        //gameObject.SetActive(false);
    }

    private void ToggleVisible()
    {
        background.enabled = !background.enabled;

        foreach( GameObject gameObject in children)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

    }
}
