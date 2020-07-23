using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    public int characterIndex = 0;
    public bool isUnlocked = false;
    public Image avatar;
    public Button switchButton;

    public void SwitchButton()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterManager>().SwitchCharacter(characterIndex);
    }
}
