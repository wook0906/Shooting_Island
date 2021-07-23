using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponDefinition
{
    public Define.WeaponType type = Define.WeaponType.None;
    public GameObject projectilePrefab;
    public int minDamage;
    public int maxDamage;
    public float delayBetweenAttack;
    public float projectileSpeed;
}

public class Weapon : Equipment
{
    public WeaponDefinition weaponDef;  
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
