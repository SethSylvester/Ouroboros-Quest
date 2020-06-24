using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    //public variables
    public float gravityDefault = 1.0f;
    //public int testItemGain = 0;

    //private variables
    private float _jumpTimer = 0.5f;
    private float _gravity;
    private float _groundDistance = 1.0f;

    private bool _jumping = false;

    //Movement Vectors
    private Vector3 _verticalGravity = new Vector3(0, 0, 0);
    private Vector3 _movement = new Vector3(0, 0, 0);

    //The character controller
    private CharacterController _controller;

    private void Start()
    {
        //Get the gravity
        gravityDefault = PlayerScriptBehavior.gravityDefault;

        //Grab the character controller
        _controller = GetComponent<CharacterController>();

        //Tell gravity to start off at its default
        _gravity = gravityDefault;
    }

    private void Jump()
    {
        //Modify gravity
        _movement += new Vector3(0, 1, 0);
        //Start the jump timer
        _jumpTimer -= Time.deltaTime;

        //when the jump timer ends
        if (_jumpTimer <= 0)
        {
            //reset it
            _jumpTimer = 0.5f;
            //No more jumping
            _jumping = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //###GRAVITY AND JUMPING###
        Gravity();

        //###PLAYER MOVEMENT###
        GetInput();

        //Jump if jumping
        if (_jumping)
            Jump();

        //Normalize after deciding which movement to use
        _movement.Normalize();

        //Set the magnitude
        _movement *= PlayerScriptBehavior.speed;
        //Finally, move the player
        _controller.Move(_movement * Time.deltaTime);

        //Tell the player to face the mouse location
        FaceDirection();
    }

    //Move the character up
    private void GoUp() { _movement += new Vector3(0, 0, 1); }
    //Move the character down
    private void GoDown() { _movement += new Vector3(0, 0, -1); }
    //Move the character left
    private void GoLeft() { _movement += new Vector3(-1, 0, 0); }
    //Move the character right
    private void GoRight() { _movement += new Vector3(1, 0, 0); }

    //Boolean to raycast to the ground and determine if the player is touching it
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _groundDistance);
    }

    private void FaceDirection()
    {
        //Find the mouse position
        Vector3 MousePos = Input.mousePosition;
        //Get a ray from the camera to the mouse
        Ray ray = Camera.main.ScreenPointToRay(MousePos);
        //Create a temporary plane at the player
        Plane plane = new Plane(Vector3.up, transform.position);
        //Find the distance from the ray to the plane
        float rayDistance = 0.0f;
        plane.Raycast(ray, out rayDistance);
        //Get the point on the ray at the distance to the plane
        Vector3 target = ray.GetPoint(rayDistance);

        //New Vector3 for direction
        Vector3 direction = new Vector3();
        //Normalize it
        direction = (target - transform.position).normalized;
        //Set forward to the direction
        transform.forward = direction;
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

    private void Teleport()
    {
        //Find the mouse position
        Vector3 MousePos = Input.mousePosition;
        //Get a ray from the camera to the mouse
        Ray ray = Camera.main.ScreenPointToRay(MousePos);

        //Create a temporary plane at the player
        Plane plane = new Plane(Vector3.up, transform.position);
        //Find the distance from the ray to the plane
        float rayDistance = 0.0f;
        plane.Raycast(ray, out rayDistance);
        //Get the point on the ray at the distance to the plane
        Vector3 target = ray.GetPoint(rayDistance);

        //Disable the controller to allow for transform.position to work
        _controller.enabled = false;
        //Teleport
        transform.position = target;
        //Reenable controller
        _controller.enabled = true;
    }

    private void GetInput()
    {
        //Find the direction
        _movement = new Vector3(0, 0, 0);

        //Jump if possible and space is pressed
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            _jumping = true;

        //Teleport
        if (PlayerScriptBehavior.shards > 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerScriptBehavior.shards--;
            Teleport();
        }

        //Up Down Left Right
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) &&
         Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) { }

        //Left Right Up
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)
                && Input.GetKey(KeyCode.D))
            GoUp();

        //Left Right Down
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)
                && Input.GetKey(KeyCode.D))
            GoDown();


        //Up Down Right
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)
                && Input.GetKey(KeyCode.D))
            GoRight();

        //Up Down Left
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)
                && Input.GetKey(KeyCode.A))
            GoLeft();

        //Up Down
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) { }

        //Left Right
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) { }

        //Up Right
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            GoUp();
            GoRight();
        }

        //Up Left
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            GoUp();
            GoLeft();
        }

        //Down Right
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            GoDown();
            GoRight();
        }
        //Down Left
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            GoDown();
            GoLeft();
        }

        //Up
        else if (Input.GetKey(KeyCode.W))
         GoUp();

        //Down
        else if (Input.GetKey(KeyCode.S))
            GoDown();

        //Left
        else if (Input.GetKey(KeyCode.A))
            GoLeft();

        //Right
        else if (Input.GetKey(KeyCode.D))
            GoRight();
    }

    ////Pick Up Item Function
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<TestPickUp>())
    //    {
    //        testItemGain++;
    //        Destroy(other.gameObject);
    //    }
    //}
}