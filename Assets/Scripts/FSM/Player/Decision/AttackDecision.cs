using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Decisions/Player/AttackDecision")]
public class AttackDecision : DecisionBase
{
    PlayerController controller;
    public override bool Decision(StateMachine fsm)
    {
        controller = fsm.transform.GetComponent<PlayerController>();
        return  controller.isTargetLockOn;

    }
}
