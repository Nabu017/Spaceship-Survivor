using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sources : professeur Felix Soumpholphakdy
public class RatHealth : MonoBehaviour
{

    [SerializeField] public int hp = 10;
    enemyKillcounter kc;

    // Update is called once per frame
  internal virtual void Damage()
    {
        if(--hp <= 0)
        {
          
            Destroy(gameObject);
            kc.killcounter++;
            Debug.Log(kc.killcounter);
        }
    }
}
