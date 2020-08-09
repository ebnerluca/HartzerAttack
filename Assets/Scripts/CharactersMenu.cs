using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharactersMenu : MonoBehaviour
{
    private List<GameObject> characters;
    public List<GameObject> characterSlots;

    public GameObject quickSelection;
    public GameObject characterDetails;

    private Sprite defaultCharacterSlotAvatar;

    private void Awake()
    {
        defaultCharacterSlotAvatar = characterSlots[0].GetComponent<CharacterSlot>().avatar.sprite;
    }

    private void OnEnable()
    {
        RefreshMenu();
        quickSelection.SetActive(true);
        characterDetails.SetActive(false);
    }
  
    private void RefreshMenu()
    {
        characters = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters();

        int i = 0;

        foreach (GameObject character in characters)
        {

            CharacterSlot characterSlot = characterSlots[i].GetComponent<CharacterSlot>();

            characterSlot.isUnlocked = character.GetComponent<CharacterSpecifics>().isUnlocked;
            characterSlot.characterIndex = i;

            characterSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = character.GetComponent<CharacterSpecifics>().characterName;

            if (characterSlot.isUnlocked)
            {
                characterSlot.avatar.sprite = character.GetComponent<Image>().sprite;
                characterSlot.switchButton.interactable = true;
            }
            else
            {
                characterSlot.avatar.sprite = defaultCharacterSlotAvatar;
                characterSlot.switchButton.interactable = false;
            }

            i++;
        }
        
    }

}
