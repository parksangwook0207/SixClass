using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomItem : Item
{
    protected void Start()
    {
        speed = 2;
        base.Init();
    }
}
