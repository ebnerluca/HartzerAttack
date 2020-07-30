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

    public TextMeshProUGUI menuButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            TogglePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleCharactersMenu();
        } else if (Input.GetKeyUp(KeyCode.Tab))
        {
            ToggleCharactersMenu();
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

        /*if (pauseMenu.activeInHierarchy)
        {
            menuButton.text = "Close";
        }
        else
        {
            menuButton.text = "Menu";
        }*/

        charactersMenu.SetActive(false);
        devMenu.SetActive(false);
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
}
