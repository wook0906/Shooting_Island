using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterFSM
{
    [CreateAssetMenu(menuName = "StateMachine/States/Monster/MoveState")]
    public class MoveState : StateBase
    {
        MonsterController controller;
        public override void OnEnterState(StateMachine fsm)
        {
            fsm.Animator.CrossFade("RUN", .1f);
            controller = fsm.GetComponent<MonsterController>();
            

            controller.nma.speed = controller.Stat.MoveSpeed;

            
        }
        public override void OnExitState(StateMachine fsm)
        {

        }
        public override void Action(StateMachine fsm, float deltaTime)
        {
            Vector3 dir = controller.LockTarget.transform.position - fsm.transform.position;
            fsm.transform.rotation = Quaternion.Slerp(fsm.transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);

            controller.SetDestination(controller.LockTarget.transform.position);
        }
    }
}
