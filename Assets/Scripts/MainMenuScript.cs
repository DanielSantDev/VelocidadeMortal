using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScrpit : MonoBehaviour
{
    public Text HighScoreText;

    void Start()
    {
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
