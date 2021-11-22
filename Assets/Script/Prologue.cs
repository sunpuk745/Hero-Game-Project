using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    void OnEnable()
    {
        // Load the game scene when enable
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
