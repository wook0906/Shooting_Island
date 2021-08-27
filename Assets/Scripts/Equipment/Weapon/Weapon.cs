using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponDefinition
{
    public Transform launchPos;
}


public abstract class Weapon : Equipment
{
    public WeaponDefinition weaponInfo;
    public abstract void Shoot(LayerMask targetLayerMask, Vector3 to);
}
