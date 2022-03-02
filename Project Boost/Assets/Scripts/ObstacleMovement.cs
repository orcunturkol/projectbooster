using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] private float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startPosition = transform.position;   
    }

    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // continuosly growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so is cleaner

        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
