using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float currentPlayerSpeed = 1f;
    private float addPlayerSpeed = 0.1f;
    private float waitTime = 3f;
    private float jumpForce = 10f;
    private float laneChangeDistance = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(AddPlayerSpeedOverTime(waitTime));
        PlayerLeftAndRight();
    }

    private IEnumerator AddPlayerSpeedOverTime(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            currentPlayerSpeed += addPlayerSpeed;
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("The player jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void PlayerLeftAndRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * laneChangeDistance;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * laneChangeDistance;
        }

    }
}
