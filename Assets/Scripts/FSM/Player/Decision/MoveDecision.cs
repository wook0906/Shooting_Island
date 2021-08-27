using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Decisions/Player/MoveDecision")]
public class MoveDecision : DecisionBase
{
    public override bool Decision(StateMachine fsm)
    {
        return fsm.GetComponent<PlayerController>().isMoving;
    }
}
