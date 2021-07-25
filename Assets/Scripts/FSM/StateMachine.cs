using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public List<StateBase> StateEntry;

    private PlayerController _owner;
    public PlayerController Owner { get { return _owner; } }
    private Animator _animator;
    public Animator Animator { get { return _animator; } }

    [HideInInspector] public bool isDamaged = false;
    [HideInInspector] public bool isMoving = false;


    public StateBase currentState;
    public StateBase prevState;
    public StateBase remainState;

    private Dictionary<string, StateBase> stateDic = new Dictionary<string, StateBase>();
    
    private void Awake()
    {
        _owner = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        foreach (var item in StateEntry)
        {
            stateDic.Add(item.name, item);
            Debug.Log(item.name);
        }
        //Managers.Resource.LoadAsync<StateBase>("Assets/_ScriptableObjects/States/SpawnState.asset",
        //    (result) =>
        //    {
        //        currentState = result.Result;
        //        currentState.OnEnterState(this);
        //    });
        currentState = stateDic["IdleState"];
        currentState.OnEnterState(this);
    }

    private void Start()
    {
        
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