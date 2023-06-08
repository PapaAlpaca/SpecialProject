using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private MouseLook cam;

    public void setVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }

    public void setSens(float sens)
    {
        cam.mouseSens = sens;
    }

    public void back()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        Pause.inSettings = false;
    }
}
