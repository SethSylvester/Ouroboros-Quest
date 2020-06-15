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

    private Attack currentAttack = new Attack();

    public float timeDefault = 1.5f;
    float time;

    [SerializeField]
    GameObject projectile1;
    [SerializeField]
    GameObject projectile2;
    [SerializeField]
    GameObject projectile3;
    [SerializeField]
    GameObject projectile4;

    bool active1 = false;
    bool active2 = false;
    bool active3 = false;
    bool active4 = false;

    public bool returning = false;


    // Start is called before the first frame update
    void Start()
    {
        //Grab the character controller
        _controller = GetComponent<CharacterController>();

        //Tell gravity to start off at its default
        _gravity = gravityDefault;
        //Calculate the Diagonal speed
        _diagonalSpeed = Mathf.Sqrt((speed * speed) + (speed * speed)) / 2;

        time = timeDefault;
    }

    // Update is called once per frame
    void Update()
    {
        //KnifeFork();
        //Gravity();
    }
    
    void KnifeFork()
    {
        //Tick down the timer
        time -= Time.deltaTime;

        //if all are active and ready to return
        if (active1 && active2 && active3 && active4 && time <= 0)
        { returning = true; }

        else if (!active1)
        {
            projectile1.SetActive(true);
            active1 = true;
        }
        else if (!active2 && time <= 0)
        {
            projectile2.SetActive(true);
            active2 = true;
            time = timeDefault;
        }
        else if (!active3 && time <= 0)
        {
            projectile3.SetActive(true);
            active3 = true;
            time = timeDefault;
        }
        else if (!active4 && time <= 0)
        {
            projectile4.SetActive(true);
            active4 = true;
            time = timeDefault;
        }
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

    private void SpreadShot()
    {

    }

}
public enum Attack
{
    None,
    Spreadshot,
    KnifeFork,
    KnifeShower
}