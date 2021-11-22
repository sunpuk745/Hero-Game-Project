using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseSystem : MonoBehaviour
{
    public bool isOpen;
    public GameObject ui_Window;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }    
    }
    void TogglePause()
    {
        isOpen = !isOpen;
        ui_Window.SetActive(isOpen);

    }
}
