using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Decisions/Player/MovingAttackDecision")]
public class MovingAttackDecision : DecisionBase
{
    PlayerController controller;
    public override bool Decision(StateMachine fsm)
    {
        controller = fsm.transform.GetComponent<PlayerController>();
        if (controller.isMoving && controller.isTargetLockOn)
            return true;
        return false;
    }
}
