using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sources : professeur Felix Soumpholphakdy
public class RatHealth : MonoBehaviour
{

    [SerializeField] public int hp = 10;
    [SerializeField] GameObject Energy;

    // Update is called once per frame
  internal virtual void Damage()
    {
        if(--hp <= 0)
        {

            Instantiate(Energy, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
          
        }
    }
}
