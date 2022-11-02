using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartPowerPickUp : MonoBehaviour
{
    [SerializeField] private PowerRuletScript _ruletScript;
    [SerializeField] private KartControllerTest kart;
    [SerializeField] private GameManager _manager;
    private TypeRunners runner => _manager._PlayerStats;
    #region RaceData

        [Space] [Header("Race Parameter")] [Space]
        
        public int ControlPointsReached = 0;
        public int TotalCrossFinishLine = 0;

    #endregion

    #region Canvas

    [Space] [Header("Canvas")] [Space] 
    
    [SerializeField] private Text TotalPlayerCrossFinishLine;

    [SerializeField] private Image TurboBar;

    public bool isUseRulet = false;
    public bool isHasPower = false;
    
    #endregion

    #region KartStats

    private float _turboBarAmount = 100;

    public float TurboAmount = 0;
    [SerializeField] private float TurboForce = 195;
    private float BaseKarVel;
    
    #endregion


    private bool isUseTurbo;
    private bool isSlowed;

    private float TimeSlowed;
    private float VelSlowed ;

    [Space]
    [Header("PowerPick")]
    [Space]
    public Transform BackPowerPos;
    public Transform ForwardPowerPos;
    private GameObject PowerHasPlayer => _ruletScript.PowerSelected;


    [Header("Skill")] [Space] 
    [SerializeField] private float SkillCoolwDown;

    [SerializeField] private GameObject Wall;
    private float _CurrentSkill;
    
    
    void Start()
    {
        kart.GetComponent<KartControllerTest>();
        
        BaseKarVel = kart.forwardSpeed;
    }

    private void Update()
    {
        
        _CurrentSkill += Time.deltaTime;
        
        UpdateUI();
        if (isUseRulet)
        {
            if (!isHasPower)
            {
                _ruletScript.isSpinRulet = true;
                isHasPower = true;
            }
         

            isUseRulet = false;
        }

        if (isUseTurbo)
        {
            if (TurboAmount >= 1)
            {
                TurboAmount -= 10 * Time.deltaTime;

                kart.forwardSpeed = TurboForce;
            }
            else
            {
                isUseTurbo = false;
                kart.forwardSpeed = BaseKarVel;

            }
        }

        if (isSlowed)
        {
            
            if (TimeSlowed > 0f)
            {
                TimeSlowed -= Time.deltaTime;
                kart.forwardSpeed = VelSlowed;
            }
            else
            {
                kart.forwardSpeed = BaseKarVel;

                isSlowed = false;
            }
        }
    }
    

   

    public void UpdateUI()
    {
        TotalPlayerCrossFinishLine.text = "" + TotalCrossFinishLine + "\n" + " /" + "\n" + "   3";
        
        TurboBar.fillAmount = TurboAmount / _turboBarAmount;
    }
    
    
    public void UsePower()
    {
        if (isHasPower && _ruletScript.StopSpin)
        {
            PowerSelectionate();
            isHasPower = false;
            _ruletScript.isSpinRulet = false;
        }
    }

    public void UseSkill()
    {
        if (_CurrentSkill >= SkillCoolwDown)
        {
            SkillSelected();
            _CurrentSkill = 0;
        }
    }

    public void UseTurbo(bool useTurbo)
    {
        isUseTurbo = useTurbo;
        if (!isUseTurbo)
        {
            kart.forwardSpeed = BaseKarVel;

        }
    }

    public void GetTurbo(float amount)
    {
        TurboAmount += amount;
    }

    public void Slowed(bool isSlowed, float TimeSlow, float velocySlow)
    {
        this.isSlowed = isSlowed;
        TimeSlowed = TimeSlow;
        VelSlowed = velocySlow;
    }

    private void PowerSelectionate()
    {
        if (PowerHasPlayer.GetComponent<MissileScript>())
        {
            // reutilizando el slowed para un boost de velocidad
           GameObject missil = Instantiate(PowerHasPlayer, ForwardPowerPos.position, Quaternion.identity);
           missil.GetComponent<MissileScript>().OwnerGameObject = this.gameObject;
            return;

        }
// if a shield
        if (PowerHasPlayer.GetComponent<WallScript>())
        {
            PowerHasPlayer.gameObject.SetActive(true);         
            return;
        }

        if (PowerHasPlayer.GetComponent<BombScript>())
        {
            GameObject bomb = Instantiate(PowerHasPlayer, BackPowerPos.position, Quaternion.identity);
            bomb.GetComponent<BombScript>().OwnerObject = this.gameObject;
            return;

        }

        if (PowerHasPlayer.GetComponent<PinchosScript>())
        {
            GameObject pincho =Instantiate(PowerHasPlayer, BackPowerPos.position, Quaternion.identity);
            pincho.GetComponent<PinchosScript>().OwnerObject = this.gameObject;
            return;
        }
    }

    void SkillSelected()
    {
        if (runner.SpecialPower.GetComponent<ShieldCollision>())
        {
            Wall.SetActive(true);
            return;
        }

        if (runner.SpecialPower.GetComponent<FakeSkill>())
        {
           GameObject Fake = Instantiate(runner.SpecialPower, BackPowerPos.position, Quaternion.identity);
           Fake.GetComponent<FakeSkill>().OwnerObject = this.gameObject;

            return;
        }
    }
}
