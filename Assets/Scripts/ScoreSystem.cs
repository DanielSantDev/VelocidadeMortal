using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public string MediumModeScene;
    public string HardModeScene;
    public string ImpossibleModeScene;
    private const int MediumModeScore = 10;
    private const int HardModeScore = 20;
    private const int ImpossibleModeScore = 30;

    void Start()
    {
        scoreText.text = "Score : " + score;

        if(!PlayerPrefs.HasKey("SceneLoaded"))
        {
            PlayerPrefs.SetInt("SceneLoaded", 0);
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver)
        {
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log("New High score is "+ score);
            } 
        }

        if (score >= ImpossibleModeScore && PlayerPrefs.GetInt("SceneLoaded") < ImpossibleModeScore)
        {
            PlayerPrefs.SetInt("SceneLoaded", ImpossibleModeScore);
            SceneManager.LoadScene("Assets/Scenes/ImpossibleModeScene.unity");
        }
        else if (score >= HardModeScore && PlayerPrefs.GetInt("SceneLoaded") < HardModeScore)
        {
            PlayerPrefs.SetInt("SceneLoaded", HardModeScore);
            SceneManager.LoadScene("Assets/Scenes/HardModeScene.unity");
        }
        else if (score >= MediumModeScore && PlayerPrefs.GetInt("SceneLoaded") < MediumModeScore)
        {
            PlayerPrefs.SetInt("SceneLoaded", MediumModeScore);
            SceneManager.LoadScene("Assets/Scenes/MediumModeScene.unity");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Obstacle")) 
        {
            score++;
            scoreText.text = "Score : " + score;
        }
    }
}
 