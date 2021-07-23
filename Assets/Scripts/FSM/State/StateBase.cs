using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : ScriptableObject
{
    public List<Transition> transitions;
    public Color gizmoColor;

    public virtual void OnEnterState(StateMachine fsm)
    {

    }

    public virtual void OnExitState(StateMachine fsm)
    {

    }

    public abstract void Action(StateMachine fsm, float deltaTime);

    public void CheckTransition(StateMachine fsm)
    {
        for (int i = 0; i < transitions.Count; i++)
        {
            bool decision = transitions[i].decision.Decision(fsm);
            if (decision)
            {
                if (transitions[i].trueState == null)
                    continue;

                fsm.ChangeState(transitions[i].trueState);
                break;
            }
            else
            {
                if (transitions[i].falseState == null)
                    continue;

                fsm.ChangeState(transitions[i].falseState);
                break;
            }
        }
    }
}
