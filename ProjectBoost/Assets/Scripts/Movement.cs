using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void OnDisable()
    {
        if(audioSource != null)
        audioSource.Stop();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainBoosterParticles.isPlaying)
        {
            mainBoosterParticles.Play();
        }
    }

     void ProcessRotation()
    {
        bool isPressingA = Input.GetKey(KeyCode.A);
        bool isPressingD = Input.GetKey(KeyCode.D);
        bool startedPressingA = Input.GetKeyDown(KeyCode.A);
        bool startedPressingD = Input.GetKeyDown(KeyCode.D);
        bool stoppedPressingA = Input.GetKeyUp(KeyCode.A);
        bool stoppedPressingD = Input.GetKeyUp(KeyCode.D);

        if (isPressingA)
        {
            ApplyRotation(rotationThrust);
        }
        else
        {
            if (isPressingD)
            {
                // sau:
                //transform.Rotate(-Vector3.forward);
                //transform.Rotate(Vector3.back * rotationThrust * Time.deltaTime);
                ApplyRotation(-rotationThrust);
            }
        }

        processingParticles(startedPressingA, startedPressingD, stoppedPressingA, stoppedPressingD);
    }

     void processingParticles(bool startedPressingA, bool startedPressingD, bool stoppedPressingA, bool stoppedPressingD)
    {
        if (startedPressingA)
        {
            rightBoosterParticles.Play();
        }
        if (stoppedPressingA)
        {
            rightBoosterParticles.Stop();
        }
        if (startedPressingD)
        {
            leftBoosterParticles.Play();
        }
        if (stoppedPressingD)
        {
            leftBoosterParticles.Stop();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
