using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Decisions/AttackDecision")]
public class AttackDecision : DecisionBase
{
    public override bool Decision(StateMachine fsm)
    {
        return fsm.isTargetLockOn;

    }
}
