using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private GameRules _rules;
    [SerializeField] private GameObject Levelpanel;
    [SerializeField] private Transform PanelSelector;
    
    private bool isSelectedKart = false;
    private bool isSelecteCharacter = false;

    #region CharactersStats
[Header("Stats")]
[Space]
    public TypeRunners Gaspi;
    public TypeRunners Marito;
    public TypeRunners BarbaKhan;
    public TypeRunners Alfredito;

    #endregion

    #region ButtonsPosition

    [Header("Buttons")] [Space] 
    [SerializeField] private GameObject GaspiButtonPos;
    [SerializeField] private GameObject MaritoButtonPos;
    [SerializeField] private GameObject BarbaKhanButtonPos;
    [SerializeField] private GameObject AlfreditoButtonPos;

    #endregion

    #region BarStats

    [SerializeField] private Image BarVel;
    [SerializeField] private Image BarAcce;
    [SerializeField] private Image BarSteering;

    #endregion

    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        BarAcce.gameObject.SetActive(false);
        BarVel.gameObject.SetActive(false);
        BarSteering.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CharactersStatsUI(string Name, string skill)
    {
        text.color = new Color(255, 255, 255);
        text.text = "Name: " + Name + "\n" +"Skill: " + skill ;
   
    }

    void KartUIStats(float Vel,float Acceleration,int Steering)
    {
        // bar
        BarAcce.gameObject.SetActive(true);
        BarVel.gameObject.SetActive(true);
        BarSteering.gameObject.SetActive(true);
                    
        BarAcce.fillAmount = Acceleration / 2;
        BarVel.fillAmount = Vel / 3;
        BarSteering.fillAmount = Acceleration / 50;
    }

    public void Kart1Selected()
    {
        _rules.PlayerCharacterStats = Gaspi;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = GaspiButtonPos.transform.position;
        isSelectedKart = true;
        CharactersStatsUI("Gaspi", "Object Theft");
    }

    public void Kart2Seleced()
    {
        _rules.PlayerCharacterStats = Alfredito;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = AlfreditoButtonPos.transform.position;
        isSelectedKart = true;
        CharactersStatsUI("Alfredito", "Force Field");

    }

    public void Kart3Seleced()
    {
        _rules.PlayerCharacterStats = Marito;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = MaritoButtonPos.transform.position;
        isSelectedKart = true;
        CharactersStatsUI("Marito", "Double Object");

    }

    public void Kart4Seleced()
    {
        _rules.PlayerCharacterStats = BarbaKhan;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = BarbaKhanButtonPos.transform.position;
        isSelectedKart = true;
        CharactersStatsUI("BarbaKhan", "Fake Object");

    }

    public void LevelPanelEnable()
    {
        if (isSelectedKart)
        {
            text.text = "";
             Levelpanel.SetActive(true);
             this.gameObject.SetActive(false);
        }
        else
        {
            text.color = new Color(255, 0, 0);
            text.text = "Choose Character";
        }


    }
}
