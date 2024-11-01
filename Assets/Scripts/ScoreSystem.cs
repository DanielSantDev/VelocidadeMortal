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

    private static ScoreSystem instance;

    private void Awake()
    {
        // Verifica se existe outra instância ativa e a destrói para evitar duplicação
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //score = PlayerPrefs.GetInt("CurrentScore", 0);
        scoreText.text = "Score : " + score;
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver){
            if(PlayerPrefs.GetInt("HighScore") < score){
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log("New High score is "+ score);
            } 
        }

        if (score >= 2)
        {
            LoadNextScene();
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

    private void LoadNextScene()
    {
        //PlayerPrefs.SetInt("CurrentScore", score);
        SceneManager.LoadScene("Assets/Scenes/MediumModeScene.unity");
    }

}