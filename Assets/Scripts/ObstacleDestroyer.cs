using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.CompareTag("Obstacle")) {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Ground")) {
            Destroy(collision.gameObject);
        }

    }
}
