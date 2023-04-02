using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int hp;
    public int energy;
    public int supernova;
    public bool powerup;


    public PlayerData(PlayerMovement2 player)
    {
        hp = player.Health;
        energy = player.EnergyCounter;
    }
    
    public PlayerData(Shooting shooter)
    {
        supernova = shooter.novaCount;
        powerup = shooter.poweredGun;
    }


    
}
