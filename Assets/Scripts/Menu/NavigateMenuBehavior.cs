using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The behavior class for the start button of the main menu
public class NavigateMenuBehavior : MonoBehaviour
{
    //0 Main Menu
    public List<GameObject> Menus;

    [SerializeField]
    Slider volume;

    public void MainMenu()
    {
        //Turn on Main Menu
        Menus[0].SetActive(true);
        //Turn off Options
        Menus[1].SetActive(false);
    }

    public void OptionsMenu()
    {
        //Turn off Main Menu
        Menus[0].SetActive(false);
        //Turn on Options
        Menus[1].SetActive(true);
        //Turn off Resolution and Volume
        Menus[2].SetActive(false);
        Menus[3].SetActive(false);
    }

    public void ResolutionMenu()
    {
        //Turn off Options
        Menus[0].SetActive(false);
        //Turn on Resolution
        Menus[2].SetActive(true);
    }

    public void VolumeMenu()
    {
        //Turn off Options
        Menus[0].SetActive(false);
        //Turn on Resolution
        Menus[3].SetActive(true);
    }

    public void SetResolution()
    {

    }

    public void SetVolume()
    {
        AudioListener.volume = volume.value;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
