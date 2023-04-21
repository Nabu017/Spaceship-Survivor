using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int hp = 100000;

    public HealthBar healthbar;



    private void Start()
    {
        healthbar.SetMaxHealth(hp);
    }

    private void Update()
    {
        healthbar.SetHealth(hp);
    }

    internal virtual void Damage()
    {
        if(--hp <= 0)
        {
            Destroy(gameObject);
        }
    }

  internal virtual  void SuperNovaDamage()
    {
        if (--hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
