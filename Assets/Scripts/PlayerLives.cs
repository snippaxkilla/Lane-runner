using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int currentLives = 3;
    [SerializeField] private int deductLive = 1;

    public bool IsDead;
    public int CurrentLives => currentLives;
    public Text livesText;

    private void Start()
    {
        IsDead = false;
        currentLives = 3;
        livesText.text = "Lives " + currentLives;
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
        //Debug.Log("Game Over");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log(("Player hit an obstacle"));
            livesText.text = "Lives " + currentLives;
            Destroy(other.gameObject);
            LoseLife();
        }
    }
}
