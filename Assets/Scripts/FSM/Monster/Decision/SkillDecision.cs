using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MonsterFSM
{
    [CreateAssetMenu(menuName = "StateMachine/Decisions/Monster/SkillDecision")]
    public class SkillDecision : DecisionBase
    {
        MonsterController controller;
        public override bool Decision(StateMachine fsm)
        {
            controller = fsm.transform.GetComponent<MonsterController>();
            if (controller.LockTarget != null &&
                controller.IsArrivedToTarget())
                return true;
            return false;
        }
    }
}
