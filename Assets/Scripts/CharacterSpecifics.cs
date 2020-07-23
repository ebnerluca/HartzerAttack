using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpecifics : MonoBehaviour
{
    public string characterName = "none";
    public float maxHealth  = 100;
    public float maxSpecial= 100;
    public float specialAbilityLoadingRate = 2.5f;
    public string specialName = "none";
    public string description = "none";

    public bool isUnlocked = false;
}
