using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int hp = 5000;




    internal virtual void Damage()
    {
        if(--hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
