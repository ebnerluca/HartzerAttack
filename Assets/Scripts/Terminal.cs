using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public void TerminalInput(string command)
    {
        if(command == "0") { GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(command); }
        else if(command == "1") { GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(command); }
        else if(command == "2") { GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(command); }
        else if(command == "3") { GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadScene(command); }
        //else if(command == "4") { }
        else if(command == "unlock all") { UnlockTrigger.UnlockCharactersAll(); }
    }
}
