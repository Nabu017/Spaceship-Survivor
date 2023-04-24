using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    // sources : https://www.youtube.com/watch?v=XOjd_qU2Ido&t=5s&ab_channel=Brackeys
    public int hp;
    public int energy;
    public int supernova;
    public bool powerup;


    public PlayerData(PlayerMovement2 player)
    {
        hp = player.totalHealth;
        energy = player.EnergyCounter;
    }
    
    public PlayerData(Shooting shooter)
    {
        supernova = shooter.novaCount;
        powerup = shooter.poweredGun;
        Debug.Log(powerup);
    }


    
}
