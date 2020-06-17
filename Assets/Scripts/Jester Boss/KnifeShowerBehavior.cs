using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeShowerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public Vector3 playerPos;

    // Update is called once per frame
    void Update()
    {
        //Track the player
        GetPlayerPos();
    }

    private void GetPlayerPos()
    {
        playerPos = (transform.position - player.transform.position).normalized;

        transform.forward = playerPos;
    }
}
