using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilityManager : MonoBehaviour
{
    private bool specialAbilityActive = false;

    public SpecialAbility currentSpecialAbility;
    public CharacterManager characterManager;
    public PlayerStats playerStats;

    public Color specialReadyColor;
    public Color specialNotReadyColor;
    public Color specialActiveColor;
    public bool specialReady = false;

    private StatusBar specialAbilityBar;
    

    void Start()
    {
        playerStats.ForceStart();

        if (GameObject.FindGameObjectWithTag("SpecialAbilityBar") != null)
        {
            specialAbilityBar = GameObject.FindGameObjectWithTag("SpecialAbilityBar").GetComponent<StatusBar>();
        }
        else
        {
            Debug.LogError("[SpecialAbilityManager]: specialAbilityBar not found. Script disabled!");
            enabled = false;
        }
    }

    public void ForceStart()
    {
        Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !specialAbilityActive)
        {
            if (playerStats.PaySpecial(currentSpecialAbility.specialCost))
            {
                ActivateSpecialAbility();
            }
            else
            {
                AudioManager.instance.Play("Error");
            }
        }
        else if (Input.GetKeyDown(KeyCode.X) && specialAbilityActive)
        {
            DeactivateSpecialAbility();
            StopAllCoroutines();
        }

        if (!specialAbilityActive)
        {
            specialAbilityBar.SetValue(Mathf.Clamp(playerStats.GetSpecial(), 0f, currentSpecialAbility.specialCost));
        }
        else
        {
            specialAbilityBar.SetValue(specialAbilityBar.slider.value -= (specialAbilityBar.slider.maxValue / currentSpecialAbility.specialDuration) * Time.deltaTime);
        }

        if (playerStats.GetSpecial() >= currentSpecialAbility.specialCost && !specialReady)
        {
            specialAbilityBar.slider.fillRect.GetComponent<Image>().color = specialReadyColor;
            specialReady = true;
        } else if(playerStats.GetSpecial() < currentSpecialAbility.specialCost && specialReady)
        {
            //specialAbilityBar.slider.fillRect.GetComponent<Image>().color = specialNotReadyColor;
            specialReady = false;
        }

    }

    public void SwitchCharacter(GameObject character)
    {
        if (specialAbilityActive)
        {
            DeactivateSpecialAbility();
            StopAllCoroutines();
        }

        specialAbilityBar.slider.fillRect.GetComponent<Image>().color = specialNotReadyColor;
        specialReady = false;

        currentSpecialAbility = character.GetComponent<SpecialAbility>();
        GameObject.FindGameObjectWithTag("UI_SpecialIcon").GetComponent<Image>().sprite = currentSpecialAbility.specialIcon;
        GameObject.FindGameObjectWithTag("SpecialBar").GetComponent<StatusBar>().SetMarkerValue(currentSpecialAbility.specialCost);
        specialAbilityBar.Initialize(Mathf.Clamp(playerStats.GetSpecial(), 0f, currentSpecialAbility.specialCost), currentSpecialAbility.specialCost);
    }

    void ActivateSpecialAbility()
    {
        if (currentSpecialAbility.specialAbility != null)
        {
            currentSpecialAbility.specialAbility.enabled = true;
            specialAbilityActive = true;
            playerStats.specialAbilityActive = true;
            characterManager.SetSpecialAbility(true);

            specialAbilityBar.slider.fillRect.GetComponent<Image>().color = specialActiveColor;

            StartCoroutine(SpecialAbilityTimer(currentSpecialAbility.specialDuration));

        }
    }

    void DeactivateSpecialAbility()
    {
        if (currentSpecialAbility.specialAbility != null)
        {
            currentSpecialAbility.specialAbility.enabled = false;
            specialAbilityActive = false;
            playerStats.specialAbilityActive = false;
            characterManager.SetSpecialAbility(false);

            specialReady = false;
            specialAbilityBar.slider.fillRect.GetComponent<Image>().color = specialNotReadyColor;
        }
    }

    IEnumerator SpecialAbilityTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        DeactivateSpecialAbility();
    }
}
