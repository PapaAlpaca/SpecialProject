using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool inSettings = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !inSettings) {
            if(isPaused) {
                resume();
            } else {
                pause();
            }
        }
    }

    public void resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void loadMenu() {
        inSettings = true;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void quit() {
        SceneManager.LoadScene(Menu.SCENE_MENU);
    }
}
