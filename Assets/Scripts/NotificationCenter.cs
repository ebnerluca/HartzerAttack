using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationCenter : MonoBehaviour
{
    public Image background;
    public Image notificationImage;
    public TextMeshProUGUI notificationType;
    public TextMeshProUGUI notificationTitle;
    public TextMeshProUGUI notificationDescription;
    public float notificationDuration = 5f;

    public GameObject[] children;

    private void Start()
    {
        background.enabled = false;

        foreach (GameObject gameObject in children)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowNotification(Notification notification)
    {
        StopAllCoroutines();

        notificationImage.sprite = notification.sprite;
        notificationType.text = notification.type;
        notificationTitle.text = notification.title;
        notificationDescription.text = notification.description;

        StartCoroutine(NotificationTimer(notification.duration));
    }

    IEnumerator NotificationTimer(float notificationDuration)
    {
        //gameObject.SetActive(true);
        //ToggleVisible();
        background.enabled = true;

        foreach (GameObject gameObject in children)
        {
            gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(notificationDuration);

        //ToggleVisible();
        //gameObject.SetActive(false);
        background.enabled = false;

        foreach (GameObject gameObject in children)
        {
            gameObject.SetActive(false);
        }
    }

    /*private void ToggleVisible()
    {
        background.enabled = !background.enabled;

        foreach( GameObject gameObject in children)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

    }*/
}
