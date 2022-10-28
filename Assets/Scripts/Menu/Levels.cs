using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField] private GameRules _rules;
    [Space]
    
    #region Maps
        [Header("MAP")]
    public GameObject PanelsMaps;

    public Image Map;

    [SerializeField] private string[] SceneName; 
    
    public Dropdown DropMapsName;
    
    private int VerifiqueChangeOptions;
    #endregion

    #region GameRulesSelection

    private int IADificult
    {
        get => _rules.DificultIA;
        set => _rules.DificultIA = value;
    }

    [SerializeField] private Text iaDifText;

    private float TimeBoxSpawn
    {
        get => _rules.TimeToSpawnBox;
        set => _rules.TimeToSpawnBox = value;
    }

    [SerializeField] private Text timeBoxText;


    [SerializeField] private Slider TimeBoxSlider;
    [SerializeField] private Slider iaSlider;
    [SerializeField] private Slider IaPlayerSlider;

    private bool isHasBalance
    {
        get => _rules.IsHasBalance;
        set => _rules.IsHasBalance = value;
    }

    private bool isUpdateUI;

    private int IAsPlayer
    {
        get => _rules.IAsPlayers;
        set => _rules.IAsPlayers = value;
    }
    [SerializeField] private Text iasPlayerCountText;


    private int TurnCount
    {
        get => _rules.TurnsCount;
        set => _rules.TurnsCount = value;
    }

    [SerializeField] private Text TurnsCountText;


    #endregion

  

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
        
        Map.sprite = DropMapsName.options[0].image;
        
        iaSlider.onValueChanged.AddListener(ChangeDificultSlider);
        TimeBoxSlider.onValueChanged.AddListener(ChangeTimeBoxSlider);
        IaPlayerSlider.onValueChanged.AddListener(ChangePlayerIASlider);
        
        iaSlider.value = IADificult;
        TimeBoxSlider.value = TimeBoxSpawn;
        IaPlayerSlider.value = IAsPlayer;
    }

  


    void Update()
    {
        if (VerifiqueChangeOptions != DropMapsName.value)
        {
            Map.sprite = DropMapsName.options[DropMapsName.value].image;
            VerifiqueChangeOptions = DropMapsName.value;
        }

        if (IADificult != _rules.DificultIA)
        {
            switch (IADificult)
            {
                case 1:
                    iaDifText.text = "Easy AI";
                    iaDifText.color = new Color(0, 255, 0);
                    break;
                case 2:
                    iaDifText.text = "Normal AI";
                    iaDifText.color = new Color(0, 0, 255);

                        break;
                    case 3:
                        iaDifText.text = "Expert AI";
                        iaDifText.color = new Color(255, 0, 0);
                        break;
                    default:
                        iaDifText.text = "Expert AI";
                        iaDifText.color = new Color(255, 0, 0);
                        break;
                    
                        
            }
            _rules.DificultIA = IADificult;
            Debug.Log(IADificult);

        }

        if (isHasBalance != _rules.IsHasBalance)
        {
            _rules.IsHasBalance = isHasBalance;
        }

        if (TimeBoxSpawn != _rules.TimeToSpawnBox)
        {
            timeBoxText.text = "" + TimeBoxSpawn;
            _rules.TimeToSpawnBox = TimeBoxSpawn;
        }

    }

    public void UpdateUI()
    {
            // Set _rules
            _rules.DificultIA = IADificult;
            _rules.IsHasBalance = isHasBalance;
            _rules.TimeToSpawnBox = TimeBoxSpawn;
            _rules.TurnsCount = TurnCount;
            _rules.IAsPlayers = IAsPlayer;
            
            //Get _rules
            
            IADificult = _rules.DificultIA;
            isHasBalance = _rules.IsHasBalance;
            TimeBoxSpawn = _rules.TimeToSpawnBox;
            TurnCount = _rules.TurnsCount;
            IAsPlayer  =_rules.IAsPlayers ;
            
            
            // update text
            TurnsCountText.text = "" + TurnCount;
            timeBoxText.text = "" + TimeBoxSpawn;
            iasPlayerCountText.text = "" + IAsPlayer;
            switch (IADificult)
            {
                case 0:
                    iaDifText.text = "Easy AI";
                    iaDifText.color = new Color(0, 255, 0);
                    break;
                case 1:
                    iaDifText.text = "Normal AI";
                    iaDifText.color = new Color(0, 0, 255);

                    break;
                case 2:
                    iaDifText.text = "Expert AI";
                    iaDifText.color = new Color(255, 0, 0);
                    break;
                default:
                    iaDifText.text = "Expert AI";
                    iaDifText.color = new Color(255, 0, 0);
                    break;
            }
    }

    public void PlayButton()
    {
        string MapSelected = $"Scenes/{SceneName[DropMapsName.value]}";
        
        if (MapSelected != String.Empty)
        {
            SceneManager.LoadScene(MapSelected);
        }
        else
        {
            Debug.Log("Scene dont exist");
        }
    }

    public void ChangeDificultSlider(float value)
    {
        IADificult = (int)value;
        UpdateUI();
    }
    public void ChangeTimeBoxSlider(float value)
    {
        TimeBoxSpawn = value;
        UpdateUI();
    }
    public void ChangePlayerIASlider(float value)
    {
        IAsPlayer = (int)value;
        UpdateUI();
    }
    public void ButtonTurns(bool SumaVueltas)
    {
        
        if (SumaVueltas)
        {
            TurnCount++;
            TurnCount = Mathf.Clamp(TurnCount, 1, 9);

        }
        else
        {
            TurnCount--;
            TurnCount = Mathf.Clamp(TurnCount, 1, 9);
        }

        TurnsCountText.text = "" + TurnCount;

    }

    public void ToogleBalance(bool value)
    {
        isHasBalance = value;
    }
}
