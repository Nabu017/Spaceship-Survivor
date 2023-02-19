using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyEnemyWorm : WormHealth
{


    [SerializeField] WormHealth original;
    [SerializeField] int damage = 1;



    internal override void Damage()
    {
        for (int i = 0; i < damage; i++)
        {
            original.Damage();
        }
    }
}
