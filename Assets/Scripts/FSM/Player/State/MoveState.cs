using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/States/Player/MoveState")]
public class MoveState : StateBase
{
    Vector2 axis;
    PlayerController controller;
    public override void OnEnterState(StateMachine fsm)
    {
        fsm.Animator.SetLayerWeight(1, 0f);
        controller = fsm.GetComponent<PlayerController>();
    }

    public override void OnExitState(StateMachine fsm)
    {

    }
    public override void Action(StateMachine fsm, float deltaTime)
    {
        axis = controller.GetCurrentMoveJoyStickAxis();
        if (axis.y >= 0f)
            fsm.transform.Translate(new Vector3(axis.x, 0, axis.y) * deltaTime * controller.Stat.MoveSpeed);
        else
            fsm.transform.Translate(new Vector3(axis.x,0, axis.y) * deltaTime * controller.Stat.MoveSpeed / 2f);

        fsm.Animator.SetFloat("xAxis", axis.x);
        fsm.Animator.SetFloat("zAxis", axis.y);


    }
    
}
