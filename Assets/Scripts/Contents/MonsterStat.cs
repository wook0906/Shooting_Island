using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : Stat
{
    public float scanRange = 20f;

    public float attackRange = 2;

    // Start is called before the first frame update
    void Start()
    {
        _level = 1;
        _hp = 100;
        _maxHp = 100;
        _attack = 10;
        _defense = 5;
        _moveSpeed = 5.0f;
    }

    public MonsterController GetController()
    {
        return GetComponent<MonsterController>();
    }
}
