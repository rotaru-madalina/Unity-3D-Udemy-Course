using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // [SerializeField] float xValue = 0.0f;

    // [SerializeField] float yValue = 0.02f;
    // [SerializeField] float zValue = 0.0f;

    [SerializeField] float moveSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(
        //    transform.position.x + 1,
        //    transform.position.y + 0,
        //    transform.position.z + 0);
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, 0, zValue);
    }

}
