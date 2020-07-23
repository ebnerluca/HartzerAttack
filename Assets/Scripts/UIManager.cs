using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject devMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            devMenu.SetActive(!devMenu.activeInHierarchy);
        }
    }
}
