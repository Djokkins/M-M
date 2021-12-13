using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        // Health = FindObjectOfType<Stats>().Health;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {jump = true;} 
        
        if (Input.GetButtonDown("Crouch"))
        {crouch = true;}
    }

    // Moving the character function
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }

}
