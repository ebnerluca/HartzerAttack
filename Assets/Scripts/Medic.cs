using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour
{

    public PlayerStats playerStats;
    public float healingRate = 5f;
    public AudioSource holySound;
    public GameObject holyRing;

    private void OnEnable()
    {
        holySound.Play();
        holyRing.SetActive(true);
    }

    private void OnDisable()
    {
        holySound.Stop();
        holyRing.SetActive(false);
    }
    private void FixedUpdate()
    {
        playerStats.IncreaseHealth(healingRate * Time.fixedDeltaTime);
    }


}
