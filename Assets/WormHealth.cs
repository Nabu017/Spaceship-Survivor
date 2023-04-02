using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHealth : MonoBehaviour
{
   [SerializeField] public int hp = 20;
    enemyKillcounter kc;



    internal virtual void Damage()
    {
        if(--hp <= 0)
        {
            Destroy(gameObject);
    
        }
    }
}
