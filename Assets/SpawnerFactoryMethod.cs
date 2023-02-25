using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFactoryMethod : MonoBehaviour
{
    ObjectPool objectpooler;

    private void Awake()
    {
        
    }
    void Start() => StartCoroutine(SpawnCoroutine());
    // Start is called before the first frame update

   
    private void FixedUpdate()
    {
    }

    IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            for(int i = 0; i < 3; i++)
            {
               EnemyFactory.Instance.CreateRat().transform.position = RandomPosition();
                EnemyFactory.Instance.CreateWorm().transform.position = RandomPosition();

            }
            yield return new WaitForSeconds(3);
        }
    }

    // Update is called once per frame
    Vector3 RandomPosition() => transform.position + Random.insideUnitSphere;
}
