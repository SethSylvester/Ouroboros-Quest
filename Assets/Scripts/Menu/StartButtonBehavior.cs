using UnityEngine;
using UnityEngine.SceneManagement;

//The behavior class for the start button of the main menu
public class StartButtonBehavior : MonoBehaviour
{
    public void StartGame()
    { SceneManager.LoadScene("Starter Island"); }

    public void MenuChange()
    { SceneManager.LoadScene("Main Menu"); }
}
