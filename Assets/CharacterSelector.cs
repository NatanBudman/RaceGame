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
    [SerializeField] private GameObject CharacterPanel;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject KartPanel;
    [SerializeField] private Transform PanelSelector;
    
    private bool isSelectedKart = false;
    private bool isSelecteCharacter = false;

    #region CharactersStats
[Header("Stats")]
[Space]
    public TypeRunners Kart1;
    public TypeRunners Kart2;
    public TypeRunners Kart3;
    public TypeRunners Kart4;

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


    #region SpecialSkills

    [Space] [Header("SpecialPowers")] [Space] 
    [SerializeField] private GameObject ForceField;
    [SerializeField] private GameObject FakeObject;
    [SerializeField] private GameObject DoubleObject;
    [SerializeField] private GameObject ObjectThieft;

    #endregion
    [Space]
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        BarAcce.gameObject.SetActive(false);
        BarVel.gameObject.SetActive(false);
        BarSteering.gameObject.SetActive(false);
    }

    void CharactersStatsUI(string Name, string skill)
    {
        text.color = new Color(255, 255, 255);
        text.text = "Name: " + Name + "\n" +"Skill: " + skill ;
   
    }

    void KartUIStats(float Vel,float Acceleration,float Steering)
    {
        // bar
        BarAcce.gameObject.SetActive(true);
        BarVel.gameObject.SetActive(true);
        BarSteering.gameObject.SetActive(true);
                    
        BarAcce.fillAmount = Acceleration / 2;
        BarVel.fillAmount = Vel / 100;
        BarSteering.fillAmount = Steering / 50;
    }

    public void Kart1Selected()
    {
        _rules.PlayerCharacterStats = Kart1;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = GaspiButtonPos.transform.position;
        isSelectedKart = true;
        KartUIStats(Kart1.velocity, Kart1.Acceleration, Kart1.TurnSpeed);

    }

    public void Kart2Seleced()
    {
        _rules.PlayerCharacterStats = Kart4;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = AlfreditoButtonPos.transform.position;
        isSelectedKart = true;
        KartUIStats(Kart2.velocity, Kart2.Acceleration, Kart2.TurnSpeed);


    }

    public void Kart3Seleced()
    {
        _rules.PlayerCharacterStats = Kart2;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = MaritoButtonPos.transform.position;
        isSelectedKart = true;
        KartUIStats(Kart3.velocity, Kart3.Acceleration, Kart3.TurnSpeed);


    }

    public void Kart4Seleced()
    {
        _rules.PlayerCharacterStats = Kart3;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = BarbaKhanButtonPos.transform.position;
        isSelectedKart = true;
        KartUIStats(Kart4.velocity, Kart4.Acceleration, Kart4.TurnSpeed);


    }

    public void GaspiSelected()
    {
        CharactersStatsUI("Gaspi", "Object Theft");
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = GaspiButtonPos.transform.position;
        _rules.PlayerCharacterStats.SpecialPower = ObjectThieft;
        isSelecteCharacter = true;

    }
    public void MaritoSelected()
    {
        CharactersStatsUI("Marito", "Double Object");
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = MaritoButtonPos.transform.position;
        _rules.PlayerCharacterStats.SpecialPower = DoubleObject;

        isSelecteCharacter = true;


    }
    public void BarbaSelected()
    {
        CharactersStatsUI("BarbaKhan", "Fake Object");
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = BarbaKhanButtonPos.transform.position;
        _rules.PlayerCharacterStats.SpecialPower = FakeObject;

        isSelecteCharacter = true;


    }
    public void AlfreditoSelected()
    {
        CharactersStatsUI("Alfredito", "Force Field");
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = AlfreditoButtonPos.transform.position;
        _rules.PlayerCharacterStats.SpecialPower = ForceField;

        isSelecteCharacter = true;


    }

    public void LevelPanelEnable()
    {
        if (isSelectedKart)
        {
            CharacterPanel.gameObject.SetActive(true);
            PanelSelector.gameObject.SetActive(false);

        }
        else
        {
            text.color = new Color(255, 0, 0);
            text.text = "Choose Kart";
        }

        if (!isSelecteCharacter && isSelectedKart)
        {
            text.text = "Choose Character";
        }
        if (isSelecteCharacter && isSelectedKart)
        {
            text.text = "";
            Levelpanel.SetActive(true);
            this.gameObject.SetActive(false);
        }


    }

    public void Return()
    {
        if (!isSelectedKart)
        {
            this.gameObject.SetActive(false);
            PanelSelector.gameObject.SetActive(false);

            MenuPanel.SetActive(true);
        }

        if (isSelectedKart)
        {
            isSelectedKart = false;
            isSelecteCharacter = false;
            text.text = "";
            CharacterPanel.SetActive(false);
            PanelSelector.gameObject.SetActive(false);
            KartPanel.SetActive(true);
        }
    }
}
