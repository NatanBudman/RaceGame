using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuInitial;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject Levels;
    [SerializeField] private GameObject Characters;



    #region KeysPanels

    private string MenuKey = "Menu";
    private string SettingKey = "Setting";
    private string LevelKey = "Levels";
    private string CharacterKey = "Characters";

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        ActivePanel(MenuKey);
    }

    void ActivePanel(string Panel)
    {
        if (Panel == "Menu")
        {
            MenuInitial.SetActive(true);
            Settings.SetActive(false);
            Levels.SetActive(false);
            Characters.SetActive(false);

        }else if (Panel == "Setting")
        {
             Settings.SetActive(true);
            MenuInitial.SetActive(false);
            Levels.SetActive(false);
            Characters.SetActive(false);

        }else if (Panel == "Levels")
        {
            Settings.SetActive(false);
            MenuInitial.SetActive(false);
            Levels.SetActive(true);
            Characters.SetActive(false);
        }else if (Panel == "Characters")
        {
            MenuInitial.SetActive(false);
            Settings.SetActive(false);
            Levels.SetActive(false);
            Characters.SetActive(true);
        }

    }

    public void AdventureButton()
    {
        ActivePanel(CharacterKey);
    }

    public void SettngButton()
    {
        ActivePanel(SettingKey);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void Return()
    {
        ActivePanel(MenuKey);
    }

    public void ReturnCharacterPanel()
    {
        ActivePanel(CharacterKey);
    }
}