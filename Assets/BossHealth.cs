using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class BossHealth : MonoBehaviour
{
    public int hp = 100000;
    public TMP_Text HealthText;
    public HealthBar healthbar;

    const string placeholder = "/100000";
    [SerializeField] SceneLoaderAdressables sceneloader;

    private void Start()
    {
        healthbar.SetMaxHealth(hp);
    }

    private void Update()
    {
        healthbar.SetHealth(hp);
        HealthText.text = hp.ToString() + placeholder;


    }

    internal virtual void Damage()
    {
        if(--hp <= 0)
        {
            HealthText.text = "0"+ placeholder;
     
            Destroy(gameObject);
           

        }
    }

  internal virtual  void SuperNovaDamage()
    {
        if (--hp <= 0)
        {
            HealthText.text = "0" + placeholder;
  
            Destroy(gameObject);
            
        }
    }
}
