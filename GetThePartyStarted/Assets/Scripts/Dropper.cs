using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float secToWait = 3.0f;
    MeshRenderer renderer;
    Rigidbody rigidBody;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }


    private void Update()
    {
        PrintElapsedTime();
        MakeObjectsVisible();

    }

    private void MakeObjectsVisible()
    {
        if (Time.time > secToWait)
        {
            renderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }

    private void PrintElapsedTime()
    {
        if(Time.time > secToWait)
        {
            Debug.Log("3 secs have elapsed.");
        }
        //Debug.Log("Time since the game has started: " + Time.time);
    }
}
