using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    protected virtual void Equip()
    {

    }
    protected virtual void UnEquip()
    {

    }
    protected PlayerController GetOwner()
    {
        return transform.root.GetComponent<PlayerController>();
    }
}
