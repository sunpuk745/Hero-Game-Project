using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Epilogue : MonoBehaviour
{
    void OnEnable()
    {
        // Load the game scene when enable
        SceneManager.LoadScene("Mainmenu", LoadSceneMode.Single);
    }
}

