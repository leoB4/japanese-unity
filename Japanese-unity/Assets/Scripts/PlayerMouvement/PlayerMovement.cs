using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    private bool isGrounded;
    private bool isMoving;

    private bool _hasAnimator;
    public Animator _animator;
    // animation IDs
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;
    private float _animationBlend;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded  && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isMoving = Mathf.Abs(x+z)!=0;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        velocity.y+= gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
        
        
        _animIDSpeed = Animator.StringToHash("Blend");
        _animator.SetFloat(_animIDSpeed, (move * speed  ).magnitude);
    }

    public bool IsMoving(){
        return isMoving;
        
    }

    public bool IsGrounded(){
        return isGrounded;
    }

}
