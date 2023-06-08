using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackB : IStrategyAttack
{
    public void GetAttackType()
    {
        Debug.Log("Player pressed B, Attack B used by enemy to deflect players attack");
    }
}
 