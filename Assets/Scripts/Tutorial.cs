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

    public GameObject marcoUnlock;
    public float marcoDisappearTimer = 50f;

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

        Invoke("DeleteMarco", marcoDisappearTimer);
    }

    void DeleteMarco()
    {
        Destroy(marcoUnlock);
        Debug.Log("[Tutorial]: marcoUnlock destroyed.");
    }

    private IEnumerator ShowNotification(float delay, Notification notification)
    {
        yield return new WaitForSeconds(delay);
        GameObject.FindGameObjectWithTag("NotificationCenter").GetComponent<NotificationCenter>().ShowNotification(notification);
        yield return new WaitForSeconds(5f);
        playerMovement.enabled = true;
    }

    public void EndLevel(float delay)
    {
        Invoke("EndLevel_", delay);
    }

    public void EndLevel_()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
