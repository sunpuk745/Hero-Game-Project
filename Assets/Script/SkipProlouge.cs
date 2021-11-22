using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkipProlouge : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Skip();
        }
    }
    public void Skip()
    {
        SceneManager.LoadScene("Main");
    }
}
