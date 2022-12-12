using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int currentLives = 3;
    [SerializeField] private int deductLive = 1;

    void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives -= deductLive;
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            Debug.Log("Game Over");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(("Player hit an obstacle"));
            Destroy(other.gameObject);
            LoseLife();
        }
    }
}
