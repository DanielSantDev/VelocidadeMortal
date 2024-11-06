using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject obstacle1, obstacle2, obstacle3;
    [HideInInspector]
    public float obstacleSpawnInterval = 2.5f;
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver) {
            StopCoroutine("SpawnObstacles");
        }

    }

    private void SpawnObstacle() {
        int random = Random.Range(1, 4);

        if(random == 1) {
            Instantiate(obstacle1, new Vector3(transform.position.x + 2.0f, 1f, 0), Quaternion.identity);
        } else if(random == 2) {
            Instantiate(obstacle2, new Vector3(transform.position.x + 2.0f, 1f, 0), Quaternion.identity);
        } else if(random == 3) {
            Instantiate(obstacle3, new Vector3(transform.position.x + 2.0f, 1f, 0), Quaternion.identity);
        } 
    }
    
    IEnumerator SpawnObstacles() {
        while(true) {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }
}
