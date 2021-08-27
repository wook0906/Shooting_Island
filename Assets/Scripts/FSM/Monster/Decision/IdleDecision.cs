using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterFSM
{
    [CreateAssetMenu(menuName = "StateMachine/Decisions/Monster/IdleDecision")]
    public class IdleDecision : DecisionBase
    {
        MonsterController controller;
        public override bool Decision(StateMachine fsm)
        {
            controller = fsm.GetComponent<MonsterController>();
            if (controller.LockTarget == null)
                return true;
            return false;
        }

    }
}
