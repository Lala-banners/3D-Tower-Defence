using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuHandler : MonoBehaviour
{
    public GameObject options;

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

    public void OptionsMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            options.SetActive(true);
            Time.timeScale = 0;
            print("Options menu appears");
        }
        //else
        //{
        //    Time.timeScale = 1;
        //    options.SetActive(false);
        //}
    }

    // Update is called once per frame
    private void Update()
    {
        OptionsMenu();
    }
}
