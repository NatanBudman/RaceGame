using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private GameRules _rules;
    [SerializeField] private GameObject Levelpanel;
    [SerializeField] private Transform PanelSelector;
    
    private bool isSelectedChararcter = false;

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

    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GaspiSelected()
    {
        _rules.PlayerCharacterStats = Gaspi;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = GaspiButtonPos.transform.position;
        isSelectedChararcter = true;
    }

    public void AlfeditoSeleced()
    {
        _rules.PlayerCharacterStats = Alfredito;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = AlfreditoButtonPos.transform.position;
        isSelectedChararcter = true;
    }

    public void MaritoSeleced()
    {
        _rules.PlayerCharacterStats = Marito;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = MaritoButtonPos.transform.position;
        isSelectedChararcter = true;
    }

    public void BarbakhanSeleced()
    {
        _rules.PlayerCharacterStats = BarbaKhan;
        PanelSelector.gameObject.SetActive(true);
        PanelSelector.transform.position = BarbaKhanButtonPos.transform.position;
        isSelectedChararcter = true;
    }

    public void LevelPanelEnable()
    {
        if (isSelectedChararcter)
        {
            text.text = "";
             Levelpanel.SetActive(true);
             this.gameObject.SetActive(false);
        }
        else
        {
            text.text = "Choose Character";
        }


    }
}
