using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuHandler : MonoBehaviour
{
    public GameObject options;


    public void Restart()
    {
        Time.timeScale = 1;
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
    public void ChangeScene(int sceneIndex) //Function to change from Main Menu scene to the game scene
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame() //Function to quit the game
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    bool isPaused = false;

    public void OptionsMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            options.SetActive(true);
            Time.timeScale = 0;
            //print("Options menu appears");
        }
        else
        {
            options.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        OptionsMenu();
    }
}
