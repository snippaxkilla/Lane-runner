using System.Collections;

using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Tests
{
    [UnityTest]
    public IEnumerator CanPlayerDieTest()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(15f);

        var playerLives = Object.FindObjectOfType<PlayerLives>();

        playerLives.LoseLife();

        if (playerLives.IsDead)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [UnityTest]
    public IEnumerator CanPlayerMoveLeftTest()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(3.25f);

        var player = Object.FindObjectOfType<PlayerMovement>();

        player.PlayerLeft();

        yield return new WaitForSeconds(1f);

        if (player.transform.position.z < -1.457f)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [UnityTest]
    public IEnumerator CanPlayerMoveRightTest()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(3.25f);

        var player = Object.FindObjectOfType<PlayerMovement>();

        player.PlayerRight();

        yield return new WaitForSeconds(1f);

        if (player.transform.position.z > -1.457f)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [UnityTest]
    public IEnumerator CanPlayerJumpTest()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(3.25f);

        var player = Object.FindObjectOfType<PlayerMovement>();

        player.PlayerJump();

        yield return new WaitForSeconds(0.25f);

        if (player.transform.position.y > 0)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [UnityTest]
    public IEnumerator CanPlayerPickupTest()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(3.25f);

        var player = Object.FindObjectOfType<PlayerMovement>();
        var playerScore = Object.FindObjectOfType<PlayerScore>();

        player.PlayerLeft();

        yield return new WaitForSeconds(3.5f);

        if (playerScore.CurrentScore > 0)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [UnityTest]
    public IEnumerator CanPlayerTakeDamageTest()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(3.25f);

        var player = Object.FindObjectOfType<PlayerMovement>();
        var playerHealth = Object.FindObjectOfType<PlayerLives>();

        yield return new WaitForSeconds(5f);

        if (playerHealth.CurrentLives < 3)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [UnityTest]
    public IEnumerator aCanPlayerWinTest()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(3f);

        var player = Object.FindObjectOfType<PlayerMovement>();
        var playerScore = Object.FindObjectOfType<PlayerScore>();

        yield return new WaitForSeconds(1.5f);
        player.PlayerRight();
        Debug.Log("Player moved right 1");

        yield return new WaitForSeconds(3.5f);
        player.PlayerRight();
        Debug.Log("Player moved right 2");

        yield return new WaitForSeconds(3f);
        player.PlayerLeft();
        Debug.Log("Player moved left 3");

        yield return new WaitForSeconds(0.35f);
        player.PlayerRight();
        Debug.Log("Player moved right 4");

        yield return new WaitForSeconds(6f);
        player.PlayerLeft();
        Debug.Log("Player moved left 5");

        yield return new WaitForSeconds(8.5f);
        player.PlayerLeft();
        Debug.Log("Player moved left 6");

        yield return new WaitForSeconds(3f);
        player.PlayerRight();
        Debug.Log("Player moved right 7");

        yield return new WaitForSeconds(5f);

        if (playerScore.CurrentScore > 0)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }
}
