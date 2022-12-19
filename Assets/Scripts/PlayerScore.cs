using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int addScoreAmount = 1;

    public int CurrentScore => currentScore;
    private int currentScore;
    public Text scoreText;

    void Start()
    {
        currentScore = 0;
        scoreText.text = "Score " + currentScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //Debug.Log(("Player picked up a score pickup"));
            currentScore += addScoreAmount;
            Destroy(other.gameObject);
            scoreText.text = "Score " + currentScore;
        }
    }
}
