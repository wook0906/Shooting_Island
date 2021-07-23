using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/States/MoveState")]
public class MoveState : StateBase
{
    public override void OnEnterState(StateMachine fsm)
    {
        fsm.Animator.CrossFade("Move", .1f);
    }

    public override void OnExitState(StateMachine fsm)
    {

    }
    public override void Action(StateMachine fsm, float deltaTime)
    {
        Vector2 axis = fsm.Owner.GetCurrentMoveJoyStickAxis();
        fsm.transform.Translate(new Vector3(axis.x,0,axis.y) * Time.deltaTime * fsm.Owner.Stat.MoveSpeed);
    }
}
