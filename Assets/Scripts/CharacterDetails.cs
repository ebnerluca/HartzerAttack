using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDetails : MonoBehaviour
{
    List<GameObject> characters = new List<GameObject>();

    public Image characterImage;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterDescription;

    public Image specialImage;
    public TextMeshProUGUI specialName;
    public TextMeshProUGUI specialDescription;

    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI maxSpecial;
    public TextMeshProUGUI specialRate;

    //default
    Sprite defaultCharacterSprite;
    string defaultCharacterName;
    string defaultCharacterDescription;

    Sprite defaultSpecialSprite;
    string defaultSpecialName;
    string defaultSpecialDescription;

    float defaultMaxHealth;
    float defaultMaxSpecial;
    float defaultSpecialRate;

    private int currentDisplayIndex = 0;


    // Start is called before the first frame update
    void Awake()
    {
        //storing defaults
        defaultCharacterSprite = characterImage.sprite;
        defaultCharacterName = characterName.text;
        defaultCharacterDescription = characterDescription.text;

        defaultSpecialSprite = specialImage.sprite;
        defaultSpecialName = specialName.text;
        defaultSpecialDescription = specialDescription.text;

        float.TryParse(maxHealth.text, out defaultMaxHealth);
        float.TryParse(maxSpecial.text, out defaultMaxSpecial);
        float.TryParse(specialRate.text, out defaultSpecialRate);
    }


    private void OnEnable()
    {
        DisplayCharacter(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCurrentCharacterIndex());
    }

    private void DisplayCharacter(int characterIndex)
    {
        //refresh character list
        characters = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters();
        GameObject character = characters[characterIndex];
        CharacterSpecifics characterSpecifics = character.GetComponent<CharacterSpecifics>();
        SpecialAbility specialAbility = character.GetComponent<SpecialAbility>();
        if (characterSpecifics.isUnlocked)
        {
            characterImage.sprite = character.GetComponent<Image>().sprite;
            characterName.text = characterSpecifics.characterName;
            characterDescription.text = characterSpecifics.description.Replace("\\n", "\n");

            specialImage.sprite = specialAbility.specialIcon; 
            specialName.text = specialAbility.specialName;
            specialDescription.text = specialAbility.specialDescription.Replace("\\n", "\n");

            maxHealth.text = characterSpecifics.maxHealth.ToString();
            maxSpecial.text = characterSpecifics.maxSpecial.ToString();
            specialRate.text = characterSpecifics.specialAbilityLoadingRate.ToString() + "/s";
        }
        else
        {
            DisplayDefault();
            DisplayCharacterPreview(characters[characterIndex]);
        }

        currentDisplayIndex = characterIndex;
    }

    public void DisplayNext()
    {
        if (currentDisplayIndex + 1 >= GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters().Count)
        {
            DisplayCharacter(0);
        }
        else
        {
            DisplayCharacter(currentDisplayIndex + 1);
        }
    }

    public void DisplayPrevious()
    {
        if (currentDisplayIndex - 1 < 0)
        {
            DisplayCharacter(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().GetCharacters().Count - 1);
        }
        else
        {
            DisplayCharacter(currentDisplayIndex - 1);
        }
    }

    private void DisplayCharacterPreview(GameObject character)
    {
        CharacterSpecifics characterSpecifics = character.GetComponent<CharacterSpecifics>();
        characterName.text = characterSpecifics.characterName;
    }

    private void DisplayDefault()
    {
        characterImage.sprite = defaultCharacterSprite;
        characterName.text = defaultCharacterName;
        characterDescription.text = defaultCharacterDescription;

        specialImage.sprite = defaultSpecialSprite;
        specialName.text = defaultSpecialName;
        specialDescription.text = defaultSpecialDescription;

        maxHealth.text = defaultMaxHealth.ToString();
        maxSpecial.text = defaultMaxSpecial.ToString();
        specialRate.text = defaultSpecialRate.ToString();
    }
}
