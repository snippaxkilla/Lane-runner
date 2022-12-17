using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float[] lanePositions;
    [SerializeField] private float laneChangeSpeed;
    [SerializeField] private float startPlayerSpeed;
    [SerializeField] private float addPlayerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTimer;
    [SerializeField] private float gravity;

    private float currentPlayerSpeed;
    private CharacterController controller;
    private float verticalVelocity;
    private bool isGrounded = true;
    private float floorHeight;
    private float currentJumpTimer;

    private int currentLane = 1;
    private float currentLanePosition;
    private float targetLanePosition;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentPlayerSpeed = startPlayerSpeed;
        currentLanePosition = lanePositions[currentLane];
        targetLanePosition = currentLanePosition;
        floorHeight = transform.position.y;
    }

    private void Update()
    {
        PlayerLeftAndRight();
        PlayerJump();

        currentPlayerSpeed += addPlayerSpeed * Time.deltaTime;
        
        if (!isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        if (currentJumpTimer > 0)
        {
            currentJumpTimer -= Time.deltaTime;
        }
        else
        {
            currentJumpTimer = 0;
        }

        if (transform.position.y <= floorHeight + 0.1f && !isGrounded && currentJumpTimer <= 0)
        {
            isGrounded = true;
            verticalVelocity = 0;
        }

        controller.Move(new Vector3(-currentPlayerSpeed, verticalVelocity, 0) * Time.deltaTime);

        if (Math.Abs(currentLanePosition - targetLanePosition) > 0.01f)
        {
            currentLanePosition = Mathf.Lerp(currentLanePosition, targetLanePosition, laneChangeSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, currentLanePosition);
        }
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
            currentJumpTimer = jumpTimer;
        }
    }

    private void PlayerLeftAndRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerRight();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerLeft();
        }
    }

    public void PlayerLeft()
    {
        currentLane--;
        if (currentLane < 0)
        {
            currentLane = 0;
        }
        targetLanePosition = lanePositions[currentLane];
    }

    public void PlayerRight()
    {
        currentLane++;
        if (currentLane > lanePositions.Length - 1)
        {
            currentLane = lanePositions.Length - 1;
        }
        targetLanePosition = lanePositions[currentLane];
    }
}
