using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = FindObjectOfType<Stats>().Health;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        

    }

    // Moving the character function
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }

}
