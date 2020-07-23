using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider masterVolumeSlider;

    public void MasterVolumeSlider()
    {
        AudioListener.volume = masterVolumeSlider.value;
    }
}
