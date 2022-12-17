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
        yield return new WaitForSeconds(3.25f);

        var player = Object.FindObjectOfType<PlayerMovement>();
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

        if (player.transform.position.x < 0)
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

        if (player.transform.position.x > 3f)
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

        if (player.transform.position.y > -4.8)
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

        player.PlayerLeft();

        yield return new WaitForSeconds(3.5f);

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

        yield return new WaitForSeconds(2.3f);
        player.PlayerRight();
        Debug.Log("Player moved right 1");


        yield return new WaitForSeconds(1.83f);
        player.PlayerLeft();
        Debug.Log("Player moved left 1");


        yield return new WaitForSeconds(1.825f);
        player.PlayerRight();
        Debug.Log("Player moved right 2");


        yield return new WaitForSeconds(1.935f);
        player.PlayerLeft();
        Debug.Log("Player moved left 2");


        yield return new WaitForSeconds(1.764f);
        player.PlayerLeft();
        Debug.Log("Player moved left 3");


        yield return new WaitForSeconds(6.493f);
        player.PlayerRight();
        Debug.Log("Player moved right 3");


        yield return new WaitForSeconds(0.339f);
        player.PlayerRight();
        Debug.Log("Player moved right 4");


        yield return new WaitForSeconds(0.954f);
        player.PlayerLeft();
        Debug.Log("Player moved left 4");


        yield return new WaitForSeconds(8.385f);
        player.PlayerRight();
        Debug.Log("Player moved right 5");


        yield return new WaitForSeconds(0.704f);
        player.PlayerLeft();
        Debug.Log("Player moved left 5");


        yield return new WaitForSeconds(0.369f);
        player.PlayerLeft();
        Debug.Log("Player moved left 6");


        yield return new WaitForSeconds(1.048f);
        player.PlayerRight();
        Debug.Log("Player moved right 6");


        yield return new WaitForSeconds(0.313f);
        player.PlayerRight();
        Debug.Log("Player moved right 7");


        yield return new WaitForSeconds(1.362f);
        player.PlayerLeft();
        Debug.Log("Player moved left 7");


        yield return new WaitForSeconds(0.973f);
        player.PlayerLeft();
        Debug.Log("Player moved left 8");


        yield return new WaitForSeconds(1.607f);
        player.PlayerRight();
        Debug.Log("Player moved right 8");


        yield return new WaitForSeconds(1.787f);
        player.PlayerRight();
        Debug.Log("Player moved right 9");


        yield return new WaitForSeconds(4.43f);
        player.PlayerLeft();
        Debug.Log("Player moved left 9");


        yield return new WaitForSeconds(0.757f);
        player.PlayerLeft();
        Debug.Log("Player moved left 10");


        yield return new WaitForSeconds(0.792f);
        player.PlayerRight();
        Debug.Log("Player moved right 10");




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
}
