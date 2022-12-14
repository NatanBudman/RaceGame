using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartPowerPickUp : MonoBehaviour
{
    [SerializeField] private PowerRuletScript _ruletScript;
    [SerializeField] private KartControllerAlternative kart;
    [SerializeField] private GameManager _manager;
    [SerializeField] private TurboSystem _turboSystem;
    [SerializeField] private PositionRace _positionRace;
    private TypeRunners runner => _manager._PlayerStats;
    #region RaceData

        [Space] [Header("Race Parameter")] [Space]
        
        public int ControlPointsReached = 0;
        private int controlAus;
        public int TotalCrossFinishLine = 0;

    #endregion

    #region Canvas

    [Space] [Header("Canvas")] [Space] 
    
    public Text TotalPlayerCrossFinishLine;

    [SerializeField] private Image TurboBar;

    [HideInInspector]  public bool isUseRulet = false;
    [HideInInspector]  public bool isHasPower = false;
    
    #endregion

    #region KartStats


    private float BaseKarVel;
    
    #endregion


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

    [SerializeField] private Image SkillCooldownImage;

    [SerializeField] private GameObject Wall;
    private float _CurrentSkill;
    
    [HideInInspector]public int FinsihPosition;


    [SerializeField] private Transform LastSpawnPosition;
    
    void Start()
    {
        
        BaseKarVel = kart.maxSpeed;
        _CurrentSkill = SkillCoolwDown;

    }

   

    private void Update()
    {
        SkillCooldownImage.fillAmount = _CurrentSkill / SkillCoolwDown;
        
        if (controlAus != ControlPointsReached)
        {
            _positionRace.AddControlPoint();
            controlAus = ControlPointsReached;
        }
        
        
        if (_manager.CountStart >= 1)
        {
            Slowed(true,_manager.CountStart + 1,0);
        }
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
        

        if (isSlowed)
        {
            
            if (TimeSlowed > 0f)
            {
                TimeSlowed -= Time.deltaTime;
                kart.currentSpeed = VelSlowed;
            }
            else
            {
                kart.currentSpeed = BaseKarVel;

                isSlowed = false;
            }
        }
        
        Debug.DrawRay(transform.position,-transform.up*5,Color.magenta);
        RaycastHit hit;

        if (Physics.Raycast(transform.position,-transform.up,out hit,5,LayerMask.GetMask("Ground")))
        {
            LastSpawnPosition.position = transform.position;
            LastSpawnPosition.rotation = hit.collider.gameObject.transform.rotation;
        }
        /*
        if (Physics.Raycast(transform.position,-transform.up,out hit,5,LayerMask.GetMask("Water")))
        {
            if (!Physics.Raycast(transform.position,-transform.up,out hit,5,LayerMask.GetMask("Ground")))
            {
                Debug.Log("entre");
                Slowed(true,3,35);
            }
        }
        */
    }
    

   

    public void UpdateUI()
    {
        TotalPlayerCrossFinishLine.text = "" + TotalCrossFinishLine + "/" + _manager.TurnsCount;
        
        TurboBar.fillAmount = _turboSystem._currentTurboAmount / _turboSystem.TotalTurboAmount;
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
           GameObject missil = Instantiate(PowerHasPlayer, ForwardPowerPos.position, transform.rotation);
           missil.GetComponent<MissileScript>().OwnerGameObject = this.gameObject;
            return;

        }
// if a shield
        if (PowerHasPlayer.GetComponent<WallScript>())
        {
            GameObject Wall = Instantiate(PowerHasPlayer,BackPowerPos.position,transform.rotation);         
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
            GameObject pincho = Instantiate(PowerHasPlayer, BackPowerPos.position, Quaternion.identity);
            pincho.GetComponent<PinchosScript>().OwnerObject = this.gameObject;
            return;
        }
    }

    private void SkillSelected()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZoneReSpawn"))
        {
            transform.position = LastSpawnPosition.position;
            transform.rotation = LastSpawnPosition.rotation;

        }
    }
}
