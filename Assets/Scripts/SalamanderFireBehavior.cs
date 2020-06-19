using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamanderFireBehavior : MonoBehaviour
{
    private CharacterController fire;
    // Start is called before the first frame update
    void Start()
    {
        fire = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        fire.Move(gameObject.transform.forward);
    }
}
