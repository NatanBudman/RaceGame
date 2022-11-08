using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class IAController : MonoBehaviour
{
    public TypeRunners IAStats;
    [SerializeField] private GameManager _manager;
    [SerializeField] private IAsManager _IAmanager;
    [SerializeField] private ItemScript _itemScript;
    [SerializeField] private TurboSystem turboSystem;
    [SerializeField] private PositionRace _positionRace;

    #region Stats
    
    private float Speed => IAStats.velocity;

    private float _currentSpeed;
    private float TurnSpeed => IAStats.TurnSpeed;

    private float _acceleration => IAStats.Acceleration;
    #endregion

    [SerializeField] private GameObject PointPref;
    [SerializeField]private GameObject[] points;
    public int _countPoint = 0;
    private int auxPoint;
    public int _RutePoint = 0;

    [SerializeField] private NavMeshAgent agent;

    [HideInInspector] public bool isSlow;
    
    public int TotalPlayerCrossFinishLine;

    public int PositionInRace;
    [HideInInspector]public int FinsihPosition;
    
    // Start is called before the first frame update
    private float timeSlow;
    private float currentSlow;
    private float SpeedSlow;

    [HideInInspector] public int TotalPointControl;


    [Space] [Header("Pos Power/Skill")] [Space] 
    
    [SerializeField] private Transform FrontPos;
    [SerializeField] private Transform BackPos;
    
    
    [Space] [Header("Raycast Power/Skill")] [Space] 
    
    [SerializeField] private float RaycastaDist;
    void Start()
    {

        _IAmanager = FindObjectOfType<IAsManager>();
        _manager = FindObjectOfType<GameManager>();

        _currentSpeed = Speed;
        
        points = new GameObject[_IAmanager.WarpPoints.Length];

        for (int i = 0; i < points.Length; i++)
        {
            GameObject AddPoints = Instantiate(PointPref);
            points[i] = AddPoints;
            points[i].transform.position = _IAmanager.WarpPoints[i].transform.position;
            
            points[i].transform.position = new Vector3(points[i].transform.position.x,
                points[i].transform.position.y, points[i].transform.position.z);
        }

        TotalPointControl = points.Length - 1;
        
        agent.speed = _currentSpeed;
        agent.acceleration = _acceleration;
        
        agent.SetDestination(points[_RutePoint].transform.position);

    }

    public void ChangeRute()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = _IAmanager.WarpPoints[i].transform.position;
            
            points[i].transform.position = new Vector3(points[i].transform.position.x+ Random.Range(0,15),
                points[i].transform.position.y, points[i].transform.position.z);
        }
    }

    private int updateRUTE;

    private bool hasTurbo;

   

    // Update is called once per frame
    void Update()
    {
        if (auxPoint != _countPoint)
        {
            _positionRace.AddControlPoint();
            auxPoint = _countPoint;
        }
        if (turboSystem._currentTurboAmount >= 1)
        {
           agent.speed = turboSystem.UseTurbo(true,agent.speed);
        }
        else
        {
            agent.speed = turboSystem.UseTurbo(false,agent.speed);
        }


// move to point
        if (_manager.CountStart >= 1)
        {
            Slowed(true,_manager.CountStart + 7,0);
        }
        
        if (_RutePoint >= points.Length)
        {
            _RutePoint = 0;
        }

        if (updateRUTE != _RutePoint)
        {
            agent.SetDestination(points[_RutePoint].transform.position);
            updateRUTE = _RutePoint;
        }
        
        
        if (Vector3.Distance(transform.position,points[_RutePoint].transform.position) <=  80)
        {
            _RutePoint += 1;
        }
        if (isSlow)
        {
            currentSlow += Time.deltaTime;
            if (currentSlow <= timeSlow)
            {
                _currentSpeed = SpeedSlow;
                agent.speed = _currentSpeed;
            }
            else
            {
                _currentSpeed = IAStats.velocity;
                agent.speed = _currentSpeed;
                isSlow = false;
            }

        }

        Debug.DrawRay(transform.position,transform.forward*RaycastaDist,Color.magenta);
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward,out hit,RaycastaDist,LayerMask.GetMask("Kart")))
        {
            isFrontItem = true;
            UsePower();
        }

        if (Physics.Raycast(transform.position, -transform.forward, out hit, RaycastaDist, LayerMask.GetMask("Kart")))
        {
            isBackItem = true;
            UsePower();
        }
    }

    private bool isFrontItem;
    private bool isFrontSkill;
    private bool isBackItem;
    private bool isBackSkill;
    public void UsePower()
    {
        if (_itemScript.Power != null)
        {
            if (isFrontItem)
            {
                if (_itemScript.Power.GetComponent<BombScript>() ||_itemScript.Power.GetComponent<WallScript>() || _itemScript.Power.GetComponent<PinchosScript>())
                {
                
                    Vector3 newQuaternion = new Vector3(transform.rotation.x,transform.rotation.y - 90,transform.rotation.z);
                    GameObject item = Instantiate(_itemScript.Power, BackPos.position, Quaternion.Euler(newQuaternion));
                    _itemScript.Power = null;
                    isBackItem = true;
                    return;
                }
            }

            if (isBackItem)
            {
                if (_itemScript.Power.GetComponent<MissileScript>())
                {
                    Vector3 newQuaternion = new Vector3(transform.rotation.x,transform.rotation.y - 90,transform.rotation.z);
                    GameObject item = Instantiate(_itemScript.Power, FrontPos.position, Quaternion.Euler(newQuaternion));
                    _itemScript.Power = null;
                    isFrontItem = false;
                    return;
                }
            }
            
           
        }
      
    }

    public void UseSkill()
    {
        
    }
    
    public void Slowed(bool isSlow, float TimeSlow, float SpeedSlow)
    {
        this.isSlow = isSlow;
        timeSlow = TimeSlow;
        this.SpeedSlow = SpeedSlow;
    }
}
