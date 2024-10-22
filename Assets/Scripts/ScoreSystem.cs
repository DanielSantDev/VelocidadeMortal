using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver){
            if(PlayerPrefs.GetInt("HighScore") < score){
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log("New High score is "+ score);
            } 
        }
    }

private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.gameObject.CompareTag("Obstacle")) {
        score = score + 1;
        scoreText.text = "Score : " + score;
    }
}

}
