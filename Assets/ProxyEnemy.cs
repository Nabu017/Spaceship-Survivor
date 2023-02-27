using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sources : professeur Felix Soumpholphakdy
public class ProxyEnemy : RatHealth
{
    [SerializeField] RatHealth original;
    [SerializeField] int damage = 1;


    internal override void Damage()
    {
        for(int i = 0; i < damage; i++)
        {
            original.Damage();
        }
    }
}
