using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyBoss : BossHealth
{
    [SerializeField] BossHealth original;
    [SerializeField] public int damage = 1;
    [SerializeField] public int supernovaDamage = 1;

    internal override void Damage()
    {
        for (int i = 0; i < damage; i++)
        {
            original.Damage();
        }
    }

    internal override void SuperNovaDamage()
    {
        for (int i = 0; i < supernovaDamage; i++)
        {
            original.SuperNovaDamage();
        }
    }
}

