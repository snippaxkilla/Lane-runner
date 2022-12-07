using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAddScore : MonoBehaviour
{
    public int currentScore;
    public int addScoreAmount = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            currentScore += addScoreAmount;
        }
    }
}
