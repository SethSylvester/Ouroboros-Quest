using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JesterBossBehavior : EnemyBehavior
{
    //private variables
    private float gravityDefault = 1.0f;
    private float speed = 5.0f;

    private float _jumpTimer = 0.5f;
    private float _gravity;
    private float _diagonalSpeed;
    private float _groundDistance = 1.0f;

    private bool _diagonalMove = false;
    private bool _jumping = false;

    //Movement Vectors
    private Vector3 _verticalGravity = new Vector3(0, 0, 0);
    private Vector3 _movement = new Vector3(0, 0, 0);

    //The character controller
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        //Grab the character controller
        _controller = GetComponent<CharacterController>();

        //Tell gravity to start off at its default
        _gravity = gravityDefault;
        //Calculate the Diagonal speed
        _diagonalSpeed = Mathf.Sqrt((speed * speed) + (speed * speed)) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
    }

    private void Gravity()
    {
        _verticalGravity = new Vector3(0, 0, 0);

        //If the player is falling increase gravity for a more weighty feeling
        if (!IsGrounded() && !_jumping && _gravity <= 30) { _gravity += 0.1f; }
        else if (IsGrounded()) { _gravity = gravityDefault; }

        //Add gravity if not jumping
        if (!_jumping) { _verticalGravity += new Vector3(0, -gravityDefault, 0); }

        //Normalize so it only goes one pixel at a time
        _verticalGravity.Normalize();
        //Multiply by gravity
        _verticalGravity *= _gravity;

        //Multiply by deltaTime for consistency and apply gravity
        _controller.Move(_verticalGravity * Time.deltaTime);
    }

    //Boolean to raycast to the ground and determine if the boss is touching it
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _groundDistance);
    }

}
