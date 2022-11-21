using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPositionn;
    [SerializeField] Vector3 movingVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPositionn = transform.position; // current position
    }

    // Update is called once per frame
    void Update()
    {
        if(period == Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner

        Vector3 offset = movingVector * movementFactor;
        transform.position = startingPositionn + offset;
    }
}
