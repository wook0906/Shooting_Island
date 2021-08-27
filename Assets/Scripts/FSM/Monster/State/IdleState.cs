using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterFSM
{
    [CreateAssetMenu(menuName = "StateMachine/States/Monster/IdleState")]
    public class IdleState : StateBase
    {
        MonsterController controller;

        public override void OnEnterState(StateMachine fsm)
        {
            fsm.Animator.CrossFade("WAIT", .1f);
            controller = fsm.GetComponent<MonsterController>();
            controller.ResetPath();
        }
        public override void OnExitState(StateMachine fsm)
        {

        }
        public override void Action(StateMachine fsm, float deltaTime)
        {
            float distance = (Managers.Game.GetPlayer().transform.position - fsm.transform.position).magnitude;
            if (distance <= controller.Stat.scanRange)
            {
                controller.LockTarget = Managers.Game.GetPlayer();
            }
        }
    }
}
