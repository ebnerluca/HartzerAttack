﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume = 1f;

    public bool loop = false;

    [HideInInspector]
    public AudioSource audioSource;


}
