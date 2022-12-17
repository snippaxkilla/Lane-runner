using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int currentLives = 3;
    [SerializeField] private int deductLive = 1;

    public bool IsDead;
    public int CurrentLives => currentLives;

    private void Start()
    {
        IsDead = false;
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives -= deductLive;
        }
        else
        {
           PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        IsDead = true;
        WaitTimeResetGame();
        Debug.Log("Game Over");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(("Player hit an obstacle"));
            Destroy(other.gameObject);
            LoseLife();
        }
    }

    IEnumerator WaitTimeResetGame()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
