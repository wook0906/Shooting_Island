using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public List<StateBase> StateEntry;

    private WorldObjectBase _owner;
    public WorldObjectBase Owner 
    { 
        get 
        { 
            return _owner;
        } 
    }
    private Animator _animator;
    public Animator Animator { get { return _animator; } }

    public StateBase currentState;
    public StateBase prevState;
    public StateBase remainState;

    private Dictionary<string, StateBase> stateDic = new Dictionary<string, StateBase>();
    
    public void Init()
    {
        _owner = GetComponent<WorldObjectBase>();
        _animator = GetComponent<Animator>();
        foreach (var item in StateEntry)
        {
            stateDic.Add(item.name, item);
        }
        //Managers.Resource.LoadAsync<StateBase>("Assets/_ScriptableObjects/States/SpawnState.asset",
        //    (result) =>
        //    {
        //        currentState = result.Result;
        //        currentState.OnEnterState(this);
        //    });
        currentState = stateDic["IdleState"];
        currentState.OnEnterState(this);

        remainState = currentState;
    }

    public void ChangeState(StateBase newState)
    {
        if (newState == null)
        {
            if (remainState != currentState)
            {
                ChangeState(remainState);
            }
            return;
        }



        if (currentState != null)
        {
            currentState.OnExitState(this);
            prevState = currentState;
        }

        StopAllCoroutines();
        currentState = newState;
        remainState = currentState;
        currentState.OnEnterState(this);
    }

    public void Update()
    {
        if (currentState == null)
        {
            return;
        }

        currentState.Action(this, Time.deltaTime);
        currentState.CheckTransition(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState == null)
            return;

        Gizmos.color = currentState.gizmoColor;
        Gizmos.DrawSphere(transform.position, 2f);
    }
}