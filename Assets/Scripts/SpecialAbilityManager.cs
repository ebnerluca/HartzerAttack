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

    private Image UI_specialIndicatorBackground;
    public Color specialReadyColor;
    public Color specialNotReadyColor;
    public bool specialReady = false;
    

    void Start()
    {
        UI_specialIndicatorBackground = GameObject.FindGameObjectWithTag("UI_SpecialIconFrame").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !specialAbilityActive)
        {
            if (playerStats.PaySpecial(currentSpecialAbility.specialCost))
            {
                ActivateSpecialAbility();
            }
        }
        else if (Input.GetKeyDown(KeyCode.X) && specialAbilityActive)
        {
            DeactivateSpecialAbility();
            StopAllCoroutines();
        }

        if(playerStats.GetSpecial() >= currentSpecialAbility.specialCost && !specialReady)
        {
            UI_specialIndicatorBackground.color = specialReadyColor;
            specialReady = true;
        } else if(playerStats.GetSpecial() < currentSpecialAbility.specialCost && specialReady)
        {
            UI_specialIndicatorBackground.color = specialNotReadyColor;
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

        UI_specialIndicatorBackground.color = specialNotReadyColor;
        specialReady = false;

        currentSpecialAbility = character.GetComponent<SpecialAbility>();
        GameObject.FindGameObjectWithTag("UI_SpecialIcon").GetComponent<Image>().sprite = currentSpecialAbility.specialIcon;
        GameObject.FindGameObjectWithTag("SpecialBar").GetComponent<StatusBar>().SetMarkerValue(currentSpecialAbility.specialCost);
    }

    void ActivateSpecialAbility()
    {
        if (currentSpecialAbility.specialAbility != null)
        {
            currentSpecialAbility.specialAbility.enabled = true;
            specialAbilityActive = true;
            playerStats.specialAbilityActive = true;
            characterManager.SetSpecialAbility(true);

            specialReady = false;
            UI_specialIndicatorBackground.color = specialNotReadyColor;

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
        }
    }

    IEnumerator SpecialAbilityTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        DeactivateSpecialAbility();
    }
}
