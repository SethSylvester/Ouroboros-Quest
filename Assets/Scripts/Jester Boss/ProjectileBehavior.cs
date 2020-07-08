using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 5.0f;

    //Movement Vectors
    private Vector3 _movement = new Vector3(0, 0, 0);

    //The character controller
    private CharacterController _controller;

    // Start is called before the first frame update
    private void Start()
    {
        //Grab the character controller
        _controller = GetComponent<CharacterController>();

        //Destroy projectiles after 5 seconds to save CPU usage.
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    private void Update()
    {
        _movement = transform.forward;

        _movement.Normalize();
        _movement *= speed;
        //Move projectile
        _controller.Move(_movement * Time.deltaTime);
    }

}
