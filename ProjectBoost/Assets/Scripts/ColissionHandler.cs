using UnityEngine;

public class ColissionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly boop :) \n");
                break;
            case "Finish":
                Debug.Log("Finish boop :) \n");
                break;
            case "Fuel":
                Debug.Log("Fuel boop :) \n");
                break;
            case "Obstacle":
                Debug.Log("Obstacle boop :( \n");
                break;
            default:
                Debug.Log("Blew up boop :( \n");
                break;
        }
    }
}
