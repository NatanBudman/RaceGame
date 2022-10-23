using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Runner", menuName = "ScriptableObject/Runners")]
public class TypeRunners : ScriptableObject
{
  [SerializeField] private Stats _stats;
  
  // Set stats
  public float velocity => _stats.velocity;

  public float Acceleration => _stats.Acceleration;

  public float EnergyConsum => _stats.EnergyConsum;
}
[System.Serializable]
public struct Stats
{
    public float velocity;

    public float Acceleration;

    public float EnergyConsum;
}
