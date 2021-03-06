using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public static inGameMenu menu;
    
    public GameObject PauseScreen;
    public GameObject ControlsScreen;
    public GameObject SettingsScreen;
    public GameObject EndLevelScreen;
    public string levelSelectScreen;
    public string nextLevelName;

    private void Awake()
    {
        // Prevent the UI from being destroyed when we reload the scene
        if (menu == null)
            menu = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }


    public void Pause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }

    public void ControlsLoad()
    {
        PauseScreen.SetActive(false);
        ControlsScreen.SetActive(true);
    }

    public void ControlsReturn()
    {
        ControlsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void SettingsLoad()
    {
        PauseScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }

    public void SettingsReturn()
    {
        SettingsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void EndLevelLoad()
    {
        // Just in case
        PauseScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        
        EndLevelScreen.SetActive(true);
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1;
        GamePaused = false;
        SceneManager.LoadScene(levelSelectScreen);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName);

        if (nextLevelName.Equals("TitleScreen"))
        {
            AudioManager.S?.Pause("Level 1");
            AudioManager.S?.Pause("Level 2");
            AudioManager.S?.Pause("Level 3");
            AudioManager.S?.Play("TitleMusic");
        }
        if (nextLevelName.Equals("Level 1"))
        {
            AudioManager.S?.Pause("TitleMusic");
            AudioManager.S?.Pause("Level 2");
            AudioManager.S?.Pause("Level 3");
            AudioManager.S?.Play("Level 1");
        }
        else if (nextLevelName.Equals("Level 2"))
        {
            AudioManager.S?.Pause("TitleMusic");
            AudioManager.S?.Pause("Level 1");
            AudioManager.S?.Pause("Level 3");
            AudioManager.S?.Play("Level 2");
        }
        else if (nextLevelName.Equals("Level 3"))
        {
            AudioManager.S?.Pause("TitleMusic");
            AudioManager.S?.Pause("Level 1");
            AudioManager.S?.Pause("Level 2");
            AudioManager.S?.Play("Level 3");
        }
    }
}