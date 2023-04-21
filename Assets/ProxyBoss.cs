using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyBoss : BossHealth
{
    [SerializeField] BossHealth original;
    [SerializeField] int damage = 1;


    internal override void Damage()
    {
        for (int i = 0; i < damage; i++)
        {
            original.Damage();
        }
    }
}
