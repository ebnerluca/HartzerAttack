﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;

    public CanvasGroup ingameButtons;

    private void OnEnable()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);

        ingameButtons.alpha = 0;
        ingameButtons.blocksRaycasts = false;

        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        ingameButtons.alpha = 1;
        ingameButtons.blocksRaycasts = true;

        Time.timeScale = 1;

    }
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

    public void RestartLevel()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
