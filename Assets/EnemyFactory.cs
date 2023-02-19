using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance { get; private set; }
    [SerializeField] GameObject Rat;
    [SerializeField] GameObject Worm;




    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
  

    public GameObject CreateRat()
    {
        GameObject enemyRat = Rat;

        return Instantiate(enemyRat, Vector3.zero, Quaternion.identity);
    }

    public GameObject CreateWorm()
    {
        GameObject enemyWorm = Worm;

        return Instantiate(Worm, Vector3.zero, Quaternion.identity);
    }
}
