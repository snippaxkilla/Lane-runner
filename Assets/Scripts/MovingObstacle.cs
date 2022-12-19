using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float direction = 1f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = startPosition + Vector3.forward * Mathf.Sin(Time.time * speed) * distance * direction;
    }
}
