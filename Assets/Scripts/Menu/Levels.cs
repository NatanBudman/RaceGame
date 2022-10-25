using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private bool isHasBalance => _rules.IsHasBalance;

    private bool isUpdateUI;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        Map.sprite = DropMapsName.options[0].image;
        
        iaSlider.onValueChanged.AddListener(ChangeDificultSlider);
        TimeBoxSlider.onValueChanged.AddListener(ChangeTimeBoxSlider);

        UpdateUI();

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

    void UpdateUI()
    {
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
            _rules.DificultIA = IADificult;
            _rules.IsHasBalance = isHasBalance;
            timeBoxText.text = "" + TimeBoxSpawn;
            _rules.TimeToSpawnBox = TimeBoxSpawn;
    }

    public void PlayButton()
    {
        string MapSelected = $"Scene/{SceneName[DropMapsName.value]}";
        
        if (MapSelected != String.Empty)
        {
            
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
}
