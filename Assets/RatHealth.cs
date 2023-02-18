using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHealth : MonoBehaviour
{

    [SerializeField] public int hp = 10;

    // Update is called once per frame
  internal virtual void Damage()
    {
        if(--hp <= 0)
        {
          
            Destroy(gameObject);
        }
    }
}
