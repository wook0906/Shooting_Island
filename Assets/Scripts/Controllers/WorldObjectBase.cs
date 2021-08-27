using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldObjectBase : MonoBehaviour
{
    protected StateMachine fsm;

    [SerializeField]
    public Define.WorldObject _worldObject = Define.WorldObject.Unknown;
    public Define.WorldObject WorldObjectType
    {
        get { return _worldObject; }
        protected set { _worldObject = value; }
    }

    private void Start()
    {
        Init();
    }
    
    public abstract void Init();
}
