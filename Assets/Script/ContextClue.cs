using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    // Context clue is the noticable sign on player's head to tell you something near player is interactable
    public GameObject contextClue;
    
    public void Enable() 
    {
        contextClue.SetActive(true);
    }

    public void Disable()
    {
        contextClue.SetActive(false);
    } 
}
