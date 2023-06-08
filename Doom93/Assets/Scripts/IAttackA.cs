using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Default attack

public class IAttackA : IStrategyAttack
{
    public void GetAttackType()
    {
        Debug.Log("Player pressed A, Attack A used by enemy to deflect players attack");
    }
}
