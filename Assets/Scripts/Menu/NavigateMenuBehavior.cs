using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The behavior class for the start button of the main menu
public class NavigateMenuBehavior : MonoBehaviour
{
    public bool fullscreen = true;

    //0 Main Menu
    public List<GameObject> menus;

    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    Dropdown resolutionDropdown;
    [SerializeField]
    Toggle fullscreenToggle;

    public void MainMenu()
    {
        //Turn on Main Menu
        menus[0].SetActive(true);
        //Turn off Options
        menus[1].SetActive(false);
    }

    public void OptionsMenu()
    {
        //Turn off Main Menu
        menus[0].SetActive(false);
        //Turn on Options
        menus[1].SetActive(true);
    }

    private void SetResolution()
    {
        switch (resolutionDropdown.value)
        {
            //640x480
            case 0:
                Screen.SetResolution(600, 480, fullscreen);
                break;
            //800x600
            case 1:
                Screen.SetResolution(800, 600, fullscreen);
                break;
            //1280x960
            case 2:
                Screen.SetResolution(1280, 960, fullscreen);
                break;
            //1600×900
            case 3:
                Screen.SetResolution(1600, 900, fullscreen);
                break;
            //1920×1080
            case 4:
                Screen.SetResolution(1920, 1080, fullscreen);
                break;
            //3840×2160
            case 5:
                Screen.SetResolution(3840, 2160, fullscreen);
                break;
        }
    }

    private void SetVolume()
    { AudioListener.volume = volumeSlider.value; }

    private void FullScreenToggle()
    { fullscreen = fullscreenToggle.enabled; }

    public void ApplyChanges()
    {
        FullScreenToggle();
        SetResolution();
        SetVolume();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
