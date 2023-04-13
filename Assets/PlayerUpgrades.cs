using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerUpgrades : MonoBehaviour
{
   [SerializeField] PlayerMovement2 playerHealth;
    [SerializeField] Shooting PlayerNova;
    public const int upgradeHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void UpgradePlayerHealth()
    {
        if (playerHealth.EnergyCounter >= 100)
        {
            playerHealth.EnergyCounter -= 100;
            playerHealth.totalHealth += upgradeHealth;
            Debug.Log("Health upgraded : " + playerHealth.Health);
            playerHealth.SavePlayer();
        }
   
    }

    public void UpgradePlayerNova()
    {
        if(playerHealth.EnergyCounter >= 100 )
        {
            playerHealth.EnergyCounter -= 100;
            PlayerNova.novaCount++;
           Debug.Log("super nova bought : " + PlayerNova.novaCount);
            PlayerNova.saveshooting();
            playerHealth.SavePlayer();
        }
      
    }
}
