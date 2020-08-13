using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<Transform> respawnPoints = new List<Transform>();
    private Transform currentRespawnPoint;
    private int currentSceneIndex;

    public static GameManager instance;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("[GameManager]: More than one GameManager detected! Destroying GameObject...");
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        respawnPoints.Clear();
        
        foreach (GameObject respawnPoint in GameObject.FindGameObjectsWithTag("Respawn"))
        {
            respawnPoints.Add(respawnPoint.transform);
            if(respawnPoint.GetComponent<RespawnPoint>().isLevelStart == true)
            {
                currentRespawnPoint = respawnPoint.transform;
            }
        }
        
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            LoadGame();
            if (currentRespawnPoint == null) { Debug.LogWarning("[GameManager]: Level start not set!"); }
        }
    }

    public bool SetRespawnPoint(Transform respawnPoint)
    {
        if(currentRespawnPoint != respawnPoint)
        {
            currentRespawnPoint = respawnPoint;
            return true;
        }

        return false;
    }


    public void RespawnPlayer(GameObject player)
    {
        Transform respawnPoint = respawnPoints[Random.Range(0, respawnPoints.Count)];
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.transform.SetPositionAndRotation(currentRespawnPoint.position, player.transform.rotation);

        player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void LoadScene(int buildIndex)
    {
        SaveGame();
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadScene(string buildIndex)
    {
        int buildIndexInteger;
        if (int.TryParse(buildIndex, out buildIndexInteger))
        {
            LoadScene(buildIndexInteger);
        }
    }

    public void SaveGame()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) { return; }

        SaveSystem.Save();
    }

    public void LoadGame()
    {
        return; //ghettofix

        if (GameObject.FindGameObjectWithTag("Player") == null) { return; }

        SaveData data = SaveSystem.Load();

        List<GameObject> characters = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters();

        int i = 0;
        foreach( bool isUnlocked in data.unlockedCharacters)
        {
            characters[i].GetComponent<CharacterSpecifics>().isUnlocked = isUnlocked;
            i++;
        }

        //LoadScene(data.sceneIndex);
    }
}
