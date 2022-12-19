using System.Collections;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    private void ResetGameForPlayer()
    {
        WaitTimeResetGame();
        //Debug.Log("Game has been reset");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            ResetGameForPlayer();
        }
    }

    static IEnumerator WaitTimeResetGame()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
