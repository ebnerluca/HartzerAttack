using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public bool[] unlockedCharacters;
    public int sceneIndex;

    public SaveData(GameObject player)
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        List<GameObject> characters = player.GetComponentInChildren<CharacterManager>().GetCharacters();

        int i = 0;
        unlockedCharacters = new bool[characters.Count];
        foreach(GameObject character in characters)
        {
            unlockedCharacters[i] = false;
            unlockedCharacters[i] = character.GetComponent<CharacterSpecifics>().isUnlocked;
            i++;
        }
    }
    
}
