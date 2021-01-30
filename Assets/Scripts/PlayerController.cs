
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;              

    private Rigidbody2D rb2d;


    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        // Basic movement input
        // TODO - refactor to be able to choose what keys affect the Input axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Set the velocity property of our Rigidbody2D rb2d to give our player some movement.
        // Elected to use velocity instead of AddForce because AddForce feels really floaty.
        rb2d.velocity = movement * speed;
    }
}