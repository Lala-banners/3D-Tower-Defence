using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
