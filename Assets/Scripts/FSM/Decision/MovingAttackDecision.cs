using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Decisions/MovingAttackDecision")]
public class MovingAttackDecision : DecisionBase
{
    public override bool Decision(StateMachine fsm)
    {
        if (fsm.isMoving && fsm.isTargetLockOn)
            return true;
        return false;
    }
}
