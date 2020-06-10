using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    private float _diagonalSpeed;

    //Movement Vectors
    private Vector3 _movement = new Vector3(0, 0, 0);

    //The character controller
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        //Grab the character controller
        _controller = GetComponent<CharacterController>();

        //Calculate the Diagonal speed
        _diagonalSpeed = Mathf.Sqrt((speed * speed) + (speed * speed)) / 2;

        //Destroy projectiles after 5 seconds to save CPU usage.
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        _movement = transform.forward;

        _movement.Normalize();
        _movement *= speed;
        //Move projectile
        _controller.Move(_movement * Time.deltaTime);
    }

    //Move the projectile up
    private void GoUp() { _movement += new Vector3(0, 0, 1); }
    //Move the projectile down
    private void GoDown() { _movement += new Vector3(0, 0, -1); }
    //Move the projectile left
    private void GoLeft() { _movement += new Vector3(-1, 0, 0); }
    //Move the projectile right
    private void GoRight() { _movement += new Vector3(1, 0, 0); }

}
