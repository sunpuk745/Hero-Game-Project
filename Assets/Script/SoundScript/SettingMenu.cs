using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SettingMenu : MonoBehaviour
{ 
    public AudioMixer audioMixer;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Main");
    }
}
