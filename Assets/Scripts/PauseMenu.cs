using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Application quit.");
        Application.Quit();
    }

    public void RespawnButton()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().RespawnPlayer(player);
        }
    }
}
