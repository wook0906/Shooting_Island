using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/States/IdleState")]
public class IdleState : StateBase
{
    public override void OnEnterState(StateMachine fsm)
    {
        fsm.Animator.CrossFade("Idle", .1f);
    }

    public override void OnExitState(StateMachine fsm)
    {

    }
    public override void Action(StateMachine fsm, float deltaTime)
    {
        
    }
}
