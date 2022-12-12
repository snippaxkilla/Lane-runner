using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    private void ResetGameForPlayer()
    {
        Debug.Log("Game has been reset");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            ResetGameForPlayer();
        }
    }
}
