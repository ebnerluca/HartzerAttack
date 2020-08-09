using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterManager : MonoBehaviour
{
    public List<GameObject> characters;
    private int currentCharacterIndex;
    public GameObject currentCharacter;

    private Animator currentAnimator;

    public float currentSpeed = 0f;
    private bool isJumping = false;
    private bool isCrouching = false;
    private bool specialAbilityActive = false;

    public SpecialAbilityManager specialAbilityManager;
    public PlayerStats playerStats;

    void Start()
    {
        SwitchCharacter(0);
    }

    void Update()
    {
        if (currentAnimator != null)
        {
            currentAnimator.SetFloat("Speed", currentSpeed); //currentSpeed is set in PlayerMovement
        }
    }

    public IEnumerator Flinch(float flinchingTime)
    {
        currentAnimator.SetBool("IsHurt", true);
        yield return new WaitForSeconds(flinchingTime);
        currentAnimator.SetBool("IsHurt", false);
    }

    public void SetJumping(bool jumpingStatus)
    {
        isJumping = jumpingStatus;
        if (currentAnimator != null) { currentAnimator.SetBool("IsJumping", isJumping); }
    }

    public void SetCrouching(bool crouchingStatus)
    {
        isCrouching = crouchingStatus;
        if (currentAnimator != null) { currentAnimator.SetBool("IsCrouching", isCrouching); }
    }

    public void SetSpecialAbility(bool isActive)
    {
        specialAbilityActive = isActive;
        if (currentAnimator != null) { currentAnimator.SetBool("SpecialAbilityActive", specialAbilityActive); }
    }

    public void SwitchCharacter(int characterIndex)
    {
        foreach (GameObject character in characters){ character.SetActive(false); }
        characters[characterIndex].SetActive(true);

        currentCharacterIndex = characterIndex;
        currentCharacter = characters[characterIndex];

        CharacterSpecifics characterSpecifics = currentCharacter.GetComponent<CharacterSpecifics>();
        playerStats.UpdateStats(characterSpecifics.maxHealth, characterSpecifics.maxSpecial, characterSpecifics.specialAbilityLoadingRate);

        currentAnimator = currentCharacter.GetComponent<Animator>();

        GameObject.FindGameObjectWithTag("UI_CharacterName").GetComponent<TextMeshProUGUI>().text = currentCharacter.GetComponent<CharacterSpecifics>().characterName;

        specialAbilityManager.SwitchCharacter(currentCharacter);
    }

    public GameObject GetCurrentCharacter()
    {
        return currentCharacter;
    }

    public int GetCurrentCharacterIndex()
    {
        return currentCharacterIndex;
    }

    public List<GameObject> GetCharacters()
    {
        return characters;
    }

    void UnlockCharacter(int characterIndex)
    {
        characters[characterIndex].GetComponent<CharacterSpecifics>().isUnlocked = true;
    }
}
