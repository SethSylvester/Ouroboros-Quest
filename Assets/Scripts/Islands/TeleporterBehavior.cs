using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    private UIBehavior ui;

    private void Start()
    {
        ui = canvas.GetComponent<UIBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerScriptBehavior.shards >= 5 && PlayerScriptBehavior.hp > 0)
        {
            ui.TeleporterButtons();
        }
    }
    //If raycasting over the teleporter
    //Set the material to a glowy texture

}
