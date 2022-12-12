using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAddScore : MonoBehaviour
{
    public int addScoreAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(("Player picked up a score pickup"));
            Destroy(gameObject);
        }
    }
}
