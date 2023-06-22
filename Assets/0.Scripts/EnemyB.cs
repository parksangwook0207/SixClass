using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    public override void Init()
    {
        data.speed = 2;
        data.hp = 12;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}