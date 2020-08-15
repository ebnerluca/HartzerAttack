using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject charactersMenu;
    public GameObject devMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if (charactersMenu.activeInHierarchy || devMenu.activeInHierarchy)
            {
                charactersMenu.SetActive(false);
                devMenu.SetActive(false);
                return;
            }

            TogglePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenCharactersMenu();
        } else if (Input.GetKeyUp(KeyCode.Tab))
        {
            CloseCharactersMenu();
        }

        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            //devMenu.SetActive(!devMenu.activeInHierarchy);
            ToggleDevMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
    }

    public void ToggleDevMenu()
    {
        pauseMenu.SetActive(false);
        charactersMenu.SetActive(false);

        devMenu.SetActive(!devMenu.activeInHierarchy);
    }

    public void ToggleCharactersMenu()
    {
        pauseMenu.SetActive(false);
        devMenu.SetActive(false);

        charactersMenu.SetActive(!charactersMenu.activeInHierarchy);
    }

    public void OpenCharactersMenu()
    {
        pauseMenu.SetActive(false);
        devMenu.SetActive(false);

        charactersMenu.SetActive(true);
    }

    public void CloseCharactersMenu()
    {
        pauseMenu.SetActive(false);
        devMenu.SetActive(false);

        charactersMenu.SetActive(false);
    }
}
