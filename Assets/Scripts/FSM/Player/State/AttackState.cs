using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/States/Player/AttackState")]
public class AttackState : StateBase
{
    Vector2 axis;
    public override void OnEnterState(StateMachine fsm)
    {
        fsm.Animator.SetLayerWeight(1, 1f);
        fsm.Animator.CrossFade("Idle", .1f,0);
        fsm.Animator.CrossFade("ATTACK", .1f);
    }

    public override void OnExitState(StateMachine fsm)
    {

    }
    public override void Action(StateMachine fsm, float deltaTime)
    {
        
    }
}
