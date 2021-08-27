using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterFSM
{
    [CreateAssetMenu(menuName = "StateMachine/States/Monster/SkillState")]
    public class SkillState : StateBase
    {
        MonsterController controller;

        public override void OnEnterState(StateMachine fsm)
        {
            fsm.Animator.CrossFade("SKILL", .1f);

            controller = fsm.GetComponent<MonsterController>();
        }
        public override void OnExitState(StateMachine fsm)
        {

        }
        public override void Action(StateMachine fsm, float deltaTime)
        {
            if (controller.LockTarget != null)
            {
                Vector3 dir = controller.LockTarget.transform.position - fsm.transform.position;
                Quaternion quat = Quaternion.LookRotation(dir);
                fsm.transform.rotation = Quaternion.Lerp(fsm.transform.rotation, quat, 20 * Time.deltaTime);
            }
        }
    }
}
