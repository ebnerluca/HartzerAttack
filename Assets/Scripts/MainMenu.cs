using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(2);
        //GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(2);
    }

    public void Quit()
    {
        Debug.Log("Application quit.");
        Application.Quit();
    }
}
