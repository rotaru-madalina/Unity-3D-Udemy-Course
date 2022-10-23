using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColissionHandler : MonoBehaviour
{
    [SerializeField] float timeDelay = 1f;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem successParticles;
    AudioSource audioSource;
    bool playerdiedorsucceeded = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly boop :) \n");
                break;
            case "Finish":
                //Debug.Log("Finish boop :) \n");
                StartSuccessSequence();
                //Invoke("LoadNextLevel", timeDelay);
                //LoadNextLevel();
                break;
            /*case "Fuel":
                Debug.Log("Fuel boop :) \n");
                break;*/
           /* case "Obstacle":
                Debug.Log("Obstacle boop :( \n");
                break; */
            default:
                //Debug.Log("Blew up boop :( \n");
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        if(playerdiedorsucceeded)
        {
            return;
        }
        audioSource.Stop();
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(successSound);
        playerdiedorsucceeded = true;
        Invoke("LoadNextLevel", timeDelay);

    }

    void StartCrashSequence()
    {
        // add particle effect
        if (playerdiedorsucceeded)
        {
            return;
        }
        audioSource.Stop();
        explosionParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(explosionSound);
        Invoke("ReloadLevel", timeDelay);
        playerdiedorsucceeded = true;

    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
