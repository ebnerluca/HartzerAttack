using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTrigger : MonoBehaviour
{
    public int unlockIndex = 0;
    public float notificationDuration = 5f;
    public string unlockSound;


    public void UnlockCharacter(int characterIndex)
    {
        List<GameObject> characters = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters();

        if (characters[characterIndex].GetComponent<CharacterSpecifics>().isUnlocked == false)
        {
            characters[characterIndex].GetComponent<CharacterSpecifics>().isUnlocked = true;

            Notification notification = new Notification();
            CharacterSpecifics characterSpecifics = characters[characterIndex].GetComponent<CharacterSpecifics>();

            notification.title = characterSpecifics.name;
            notification.text = "Character unlocked!";
            notification.duration = notificationDuration;

            Debug.Log("Character unlocked!", characters[characterIndex]);
            GameObject.FindGameObjectWithTag("NotificationCenter").GetComponent<NotificationCenter>().ShowNotification(notification);
            AudioManager.instance.Play(unlockSound);

            Destroy(gameObject);
        }
    }

    public static void UnlockCharactersAll() //console only
    {
        int k = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters().Count;
        List<GameObject> characters = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters();

        for (int i = 0; i < k; i++)
        {
            characters[i].GetComponent<CharacterSpecifics>().isUnlocked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnlockCharacter(unlockIndex);
    }
}
