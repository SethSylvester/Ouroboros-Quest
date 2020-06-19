using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    //Gets the health fields
    [SerializeField]
    public RawImage health1;
    [SerializeField]
    public RawImage health2;
    [SerializeField]
    public RawImage health3;

    //Textures for the health fields
    [SerializeField]
    public Texture heartFull;
    [SerializeField]
    public Texture heartEmpty;

    //The text portions of the UI
    [SerializeField]
    public Text shards;
    [SerializeField]
    public Text currentWeapon;
    [SerializeField]
    public Text attackSpeed;
    [SerializeField]
    public Text speed;

    // Update is called once per frame
    private void Update()
    {
        //Displays the health amount
        DisplayHealth();
        //Displays weapon name
        currentWeapon.text = PlayerScriptBehavior.weapon.ToString();
        //Displays attack speed
        attackSpeed.text = "Attack Speed: " + PlayerScriptBehavior.attackDelay.ToString();
        //displays normal speed
        speed.text = "Movement Speed: " + PlayerScriptBehavior.speed.ToString();
        //displays the amount of shards
        shards.text = PlayerScriptBehavior.shards.ToString();
    }

    private void DisplayHealth()
    {
        if (PlayerScriptBehavior.hp == 3) 
        {
            health1.texture = heartFull;
            health2.texture = heartFull;
            health3.texture = heartFull;
        }
        else if (PlayerScriptBehavior.hp == 2) {
            health1.texture = heartFull;
            health2.texture = heartFull;
            health3.texture = heartEmpty;
        }
        else if (PlayerScriptBehavior.hp == 1) {
            health1.texture = heartFull;
            health2.texture = heartEmpty;
            health3.texture = heartEmpty;
        }
        else if (PlayerScriptBehavior.hp <= 0) {
            health1.texture = heartEmpty;
            health2.texture = heartEmpty;
            health3.texture = heartEmpty;
        }
    }
}
