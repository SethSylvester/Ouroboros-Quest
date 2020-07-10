using UnityEngine;
using UnityEngine.SceneManagement;

//The behavior class for the start button of the main menu
public class StartButtonBehavior : MonoBehaviour
{
    public void StartGame()
    {
        //Resets the player's stats
        PlayerScriptBehavior.hp = 3;
        PlayerScriptBehavior.shards = 10;
        PlayerScriptBehavior.speed = 5.0f;
        PlayerScriptBehavior.damage = 1;

        //Loads the Starter Island
        SceneManager.LoadScene("Starter Island"); 
    }

    public void MenuChange()
    {       
        SceneManager.LoadScene("Main Menu");   
    }
}
