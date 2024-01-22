using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStatModifiers : PickupItem
{
    [SerializeField] List<CharStats> statsModifier;
    protected override void OnPickedUp(GameObject receiver)
    {
        CharStatsHandler statsHandler = receiver.GetComponent<CharStatsHandler>();

        foreach (CharStats stat in statsModifier) 
        {
            statsHandler.AddStatModifier(stat);
        }
    }
}
