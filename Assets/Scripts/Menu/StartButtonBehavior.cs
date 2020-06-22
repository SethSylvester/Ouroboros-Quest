using UnityEngine;
using UnityEngine.SceneManagement;

//The behavior class for the start button of the main menu
public class StartButtonBehavior : MonoBehaviour
{
    public void StartGame()
    { SceneManager.LoadScene(1); }
}
