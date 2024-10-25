using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Assets/Scenes/MainMenuScene.unity");
    }

    public void LoadSampleMenu()
    {
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
    }

    public void LoadMediumModeScene()
    {
        SceneManager.LoadScene("Assets/Scenes/LoadMediumModeScene.unity");
    }

    public void LoadHardModeScene()
    {
        SceneManager.LoadScene("Assets/Scenes/LoadHardModeScene.unity");
    }

    public void LoadImpossibleModeScene()
    {
        SceneManager.LoadScene("Assets/Scenes/LoadImpossibleModeScene.unity");
    }
}
