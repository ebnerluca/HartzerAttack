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

    private RectTransform rectTransform;
    private Vector2 baseOffsetMin;
    private float baseHeight;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        baseOffsetMin = rectTransform.offsetMin;
        baseHeight = rectTransform.offsetMax.y - rectTransform.offsetMin.y;
    }

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
        notificationDescription.text = notification.description.Replace("\\n", "\n");
       
        rectTransform.offsetMin = baseOffsetMin;
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, rectTransform.offsetMax.y - notification.scale*baseHeight);

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

        rectTransform.offsetMin = baseOffsetMin;
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
