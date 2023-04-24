using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHealth : MonoBehaviour
{
   [SerializeField] public int hp = 20;
    [SerializeField] GameObject Energy;




    internal virtual void Damage()
    {
        if(--hp <= 0)
        {
            Instantiate(Energy, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
    
        }
    }
}
