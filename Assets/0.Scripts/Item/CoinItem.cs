using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : Item
{
    private void Start()
    {
        speed = 2;
        base.Init();
    }
}
