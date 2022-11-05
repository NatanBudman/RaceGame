using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class IAController : MonoBehaviour
{
    public TypeRunners IAStats;

    [SerializeField] private IAsManager _IAmanager;

    #region Stats
    
    private float Speed => IAStats.velocity;

    private float _currentSpeed;
    private float TurnSpeed => IAStats.TurnSpeed;
    #endregion

    [SerializeField] private GameObject PointPref;
    [SerializeField]private GameObject[] points;
    public int _countPoint = 0;
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

    [SerializeField] private float TurboAddVelocity;
    private float turboAmount;
    
    void Start()
    {

        TurboAddVelocity += Speed;
        
        _IAmanager = FindObjectOfType<IAsManager>();

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
      //  agent.speed = _currentSpeed;
        
        agent.SetDestination(points[_RutePoint].transform.position);

    }

    public void ChangeRute()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = _IAmanager.WarpPoints[i].transform.position;
            
            points[i].transform.position = new Vector3(points[i].transform.position.x,
                points[i].transform.position.y, points[i].transform.position.z);
        }
    }

    private int updateRUTE;
    // Update is called once per frame
    void Update()
    {
// move to point

        if (turboAmount >= 1)
        {
            turboAmount -= 5 * Time.deltaTime;
            _currentSpeed = TurboAddVelocity;
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
        
        
        if (Vector3.Distance(transform.position,points[_RutePoint].transform.position) <=  75)
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
    }

    public void AddTurbo(float addTurbo)
    {
        turboAmount += addTurbo;
    }

    public void Slowed(bool isSlow, float TimeSlow, float SpeedSlow)
    {
        this.isSlow = isSlow;
        timeSlow = TimeSlow;
        this.SpeedSlow = SpeedSlow;
    }
}
