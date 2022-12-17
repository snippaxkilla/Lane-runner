using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int addScoreAmount = 1;
    
    private int currentScore;

    public int CurrentScore => currentScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Debug.Log(("Player picked up a score pickup"));
            currentScore += addScoreAmount;
            Destroy(other.gameObject);
        }
    }
}
