using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
   [SerializeField] PlayerMovement2 playerHealth;
    [SerializeField] Shooting PlayerNova;
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
            playerHealth.Health += 100;
            Debug.Log("Health upgraded : " + playerHealth.Health);
        }
   
    }

    public void UpgradePlayerNova()
    {
        if(playerHealth.EnergyCounter >= 100 )
        {
            playerHealth.EnergyCounter -= 100;
            PlayerNova.novaCount++;
           Debug.Log("super nova bought : " + PlayerNova.novaCount);
        }
      
    }
}
