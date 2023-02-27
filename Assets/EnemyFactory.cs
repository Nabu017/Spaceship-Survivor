using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// sources : professeur Felix Soumpholphakdy
public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance { get; private set; }
    [SerializeField] GameObject Rat;
    [SerializeField] GameObject Worm;
    ObjectPool objectpooler;
    private Transform spawnerTransform;



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
    private void Start()
    {
        objectpooler = ObjectPool.Instance;
       
    }

    public GameObject CreateRat()
    {
        GameObject enemyRat = Rat;
       // Rat = objectpooler.SpawnfromPool("Rat", Vector3.zero, Quaternion.identity);
        return Instantiate(enemyRat, Vector3.zero, Quaternion.identity);
        //return Rat;

    }

    public GameObject CreateWorm()
    {
        GameObject enemyWorm = Worm;

        return Instantiate(Worm, Vector3.zero, Quaternion.identity);

    }
}
