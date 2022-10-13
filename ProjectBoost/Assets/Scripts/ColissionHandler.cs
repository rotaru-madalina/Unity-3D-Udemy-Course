using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColissionHandler : MonoBehaviour
{
    [SerializeField] float timeDelay = 1f;
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
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", timeDelay);
    }

    void StartCrashSequence()
    {
        // add SFX upon crash
        // add particle effect
        GetComponent<Movement>().enabled = false;
        //GetComponent<AudioSource>().Stop();
        Invoke("ReloadLevel", timeDelay);
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
