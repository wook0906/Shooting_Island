using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWorldObject : MonoBehaviour
{
    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;

    private void Start()
    {
        Init();
    }


    public abstract void Init();
}
