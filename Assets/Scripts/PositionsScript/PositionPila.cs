using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPila : MonoBehaviour
{
   [SerializeField] private PositionRace[] KartPosition;
    private int index;

    public void InicializateTDA(int Amount)
    {
        KartPosition = new PositionRace[Amount];
        index = 0;
    }

    public void StackKartsPositions(PositionRace kart)
    {
        int j;
        for (j = index; j > 0 &&  KartPosition[j - 1].TotalPoitns >= kart.TotalPoitns; j--)
        {
            KartPosition[j] = KartPosition[j - 1];
        }

        KartPosition[j] = kart;
        index++;
    }

    public void Unstack() => index--;

    public PositionRace TopPlayer() => KartPosition[index - 1];

    public void UnstackPosition()
    {
        KartPosition[index - 1] = null;
        index--;
    }

    public void ResetTDA() => index = 0;

    public bool EmptyTDA() => index >= KartPosition.Length;
}
