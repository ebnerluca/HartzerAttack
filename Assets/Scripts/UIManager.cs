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
        devMenu.SetActive(!devMenu.activeInHierarchy);

        pauseMenu.SetActive(false);
        charactersMenu.SetActive(false);
        
    }

    public void ToggleCharactersMenu()
    {
        charactersMenu.SetActive(!charactersMenu.activeInHierarchy);

        pauseMenu.SetActive(false);
        devMenu.SetActive(false);

    }

    public void OpenCharactersMenu()
    {
        charactersMenu.SetActive(true);

        pauseMenu.SetActive(false);
        devMenu.SetActive(false);
    }

    public void CloseCharactersMenu()
    {
        charactersMenu.SetActive(false);

        pauseMenu.SetActive(false);
        devMenu.SetActive(false);
    }
}
