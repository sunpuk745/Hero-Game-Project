using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    public bool isOpen;
    public GameObject ui_Window;

    void ChangePhase()
    {
        isOpen = !isOpen;
        ui_Window.SetActive(isOpen);
    }
}
