﻿using UnityEngine;

public class KnifeForkProjectileBehavior : MonoBehaviour
{
    private float timeDefault = 0.8f;
    private float returnTime;
    private float time;

    public Vector3 playerPos;
    public Vector3 parentPos;

    private float speedDefault = 15.0f;
    public float speed;

    [SerializeField]
    private GameObject jester;
    [SerializeField]
    private GameObject player;

    private Vector3 _movement = new Vector3(0, 0, 0);

    //The character controller
    private CharacterController _controller;

    private bool hasPlayerPos = false;

    // Start is called before the first frame update
    private void Start()
    {
        speed = speedDefault;
        //timeDefault = jester.GetComponent<JesterBossBehavior>().timeDefault;
        returnTime = timeDefault;
        time = timeDefault;
        //Grab the character controller
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        time -= Time.deltaTime;
        if (!hasPlayerPos)
        {
            GetPlayerPos();
        }
        if (jester.GetComponent<JesterBossBehavior>().returning)
        {
            time = timeDefault;
            speed = 20;

            ReturnBullet();

            returnTime -= Time.deltaTime;
            if (returnTime <= 0)
            {
                ResetBullet();
            }
        }
        else if (time >= 0)
        {
            MoveBulletForward();
        }
    }

    private void GetPlayerPos()
    {
        hasPlayerPos = true;

        playerPos = (player.transform.position - jester.transform.position).normalized;

        transform.forward = playerPos;
    }

    private void MoveBulletForward()
    {
        //Find the players location and launch bullet to there
        _movement = transform.forward;

        _movement.Normalize();
        _movement *= speed;
        //Move projectile
        _controller.Move(_movement * Time.deltaTime);
    }

    public void ReturnBullet()
    {
        //Bullet goes back to the jester and deactivates
        parentPos = (jester.transform.position - transform.position).normalized;
        transform.forward = parentPos;

        _movement = transform.forward;

        _movement.Normalize();
        _movement *= speed;
        //Move projectile
        _controller.Move(_movement * Time.deltaTime);
    }

    private void ResetBullet()
    {
        //Reset the two different timers
        time = timeDefault;
        returnTime = timeDefault;

        //Reset the position of the bullet
        _controller.enabled = false;
        Vector3 parentPos = jester.transform.position;
        parentPos.z -= 1f;
        transform.position = parentPos;
        _controller.enabled = true;

        //Disable the bullet
        gameObject.SetActive(false);
        
        //Fix the bullets rotation
        gameObject.transform.rotation = new Quaternion(0, 0.38f, 0, 0);

        //Reset the speed and tell it to track the player next time
        speed = speedDefault;
        hasPlayerPos = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerMovementBehavior>() != null)
        {
            ResetBullet();
            other.gameObject.GetComponentInParent<PlayerScriptBehavior>().TakeDamage(1);
        }
    }

}
