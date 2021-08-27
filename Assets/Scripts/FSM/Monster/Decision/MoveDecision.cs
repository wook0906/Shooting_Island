using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterFSM
{
    [CreateAssetMenu(menuName = "StateMachine/Decisions/Monster/MoveDecision")]
    public class MoveDecision : DecisionBase
    {
        MonsterController controller;
        public override bool Decision(StateMachine fsm)
        {
            controller = fsm.GetComponent<MonsterController>();

            if (controller.LockTarget != null &&
                !controller.IsArrivedToTarget())
                return true;
            return false;
        }
    }
}
