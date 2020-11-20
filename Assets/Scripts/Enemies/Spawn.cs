using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Managers;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;
    private float currentTime = 0;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] Transform wayPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = EnemyManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if(currentTime < spawnRate)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            if (enemyManager != null) 
            {
                enemyManager.SpawnEnemy(transform, wayPoint);
            }
        }

    
    }
}
