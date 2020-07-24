using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSongStarter : MonoBehaviour
{
    private void Awake()
    {
        AudioManager.instance.Play("Euromir_Theme");
    }
}
