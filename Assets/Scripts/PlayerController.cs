using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float runSpeed;
    private int jumpCount = 0;
    private bool canJump = true;
    Animator anim;
    public bool isGameOver = false;
    public GameObject GameOverPanel, scoreText;
    public Text FinalScoreText, HighScoreText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("IncreaseGameSpeed");
    }

    void Update()
    {
        if(!isGameOver){
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        }
    
        if(jumpCount == 2) {
            canJump = false;
        }

        if (Input.GetButtonDown("Jump") && canJump && !isGameOver) {
            rb2d.velocity = Vector2.up * 7.5f;
            anim.SetTrigger("jump");
            jumpCount += 1;
            Debug.Log(jumpCount);
        }
    }

    public void GameOver() {
        isGameOver = true;
        anim.SetTrigger("death");
        StopCoroutine("IncreaseGameSpeed");
        StartCoroutine("ShowGameOverPanel");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
        jumpCount = 0;
        canJump = true;
        }else if(collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("BottomDetector")) {
        GameOver();
        }
    }

    IEnumerator IncreaseGameSpeed() {
        while(true) {
            yield return new WaitForSeconds(10);

            if(runSpeed < 16){
                runSpeed += 0.2f;
            }

            if(GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval > 1){
                GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval -= 0.1f;
            }
        }
    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);

        FinalScoreText.text = "Score : " + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

    public void JumpButton(){
        if (canJump && !isGameOver)
        {
            rb2d.velocity = Vector2.up * 7.5f;
            anim.SetTrigger("jump");
            jumpCount += 1;
        }
    }
}
