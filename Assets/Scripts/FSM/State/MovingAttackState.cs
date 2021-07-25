using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/States/MovingAttackState")]
public class MovingAttackState : StateBase
{
    Vector2 axis;
    public override void OnEnterState(StateMachine fsm)
    {
        fsm.Animator.SetLayerWeight(1, 1f);
        fsm.Animator.CrossFade("ATTACK", .1f, 1);
    }

    public override void OnExitState(StateMachine fsm)
    {

    }
    public override void Action(StateMachine fsm, float deltaTime)
    {
        axis = fsm.Owner.GetCurrentMoveJoyStickAxis();
        if (axis.y >= 0f)
            fsm.transform.Translate(new Vector3(axis.x, 0, axis.y) * deltaTime * fsm.Owner.Stat.MoveSpeed);
        else
            fsm.transform.Translate(new Vector3(axis.x, 0, axis.y) * deltaTime * fsm.Owner.Stat.MoveSpeed / 2f);
        fsm.Animator.SetFloat("xAxis", axis.x);
        fsm.Animator.SetFloat("zAxis", axis.y);

        
    }
}
