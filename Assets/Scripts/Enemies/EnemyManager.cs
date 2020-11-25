using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Enemies;
using TMPro;

//namespaces - categories of things
//TowerDefence.Managers will have access to TowerDefence.Enemies because there is an EnemyManager
namespace TowerDefence.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance = null;
        void Awake()
        {
            if (Instance != null)
                Destroy(Instance.gameObject);
            Instance = this;
        }

        public int currentGraveyardCapacity = 0; //Claire named it
        //Make a singleton to spawn enemies from everywhere 
        public TMP_Text enemyCount;
        [SerializeField]
        private Inventory inventory;
        [SerializeField]
        private GameObject enemyPrefab;

        //List to create new enemies
        private List<EnemyStats> aliveEnemies = new List<EnemyStats>();

        //Function to spawn enemies
        public void SpawnEnemy(Transform _spawner, Transform wayPoint)
        {
            GameObject enemyOne = Instantiate(enemyPrefab, _spawner.position, enemyPrefab.transform.rotation); // null ref check if null
            EnemyStats enemy = enemyOne.GetComponent<EnemyStats>();

            int count = wayPoint.childCount;

            GameObject[] enemyPaths = new GameObject[count];
            for(int i = 0; i < count ;i++)
            {
                enemyPaths[i] = wayPoint.GetChild(i).gameObject;
            }
            enemy.enemyPaths = enemyPaths;

            aliveEnemies.Add(enemy);
            currentGraveyardCapacity++;
        }

        public void KillEnemy(EnemyStats _enemy)
        {
            inventory.money += _enemy.worth;
            enemyCount.text = $"Enemies Killed: {currentGraveyardCapacity}"; //Display how many enemies have died

            if (aliveEnemies.Contains(_enemy))
            {
                aliveEnemies.Remove(_enemy);
            }

            Destroy(_enemy.gameObject);
        }

        /// <summary>
        /// Loops through all aliveEnemies in the game and finds the closest enemies within a certain range
        /// </summary>
        /// <param name="_target">The object we are comparing the distance to.</param>
        /// <param name="_maxRange">The range we are finding enemies with.</param>
        /// <param name="_minRange">The range the enemies must at least be from the target.</param>
        /// <returns>The list of enemies within the given range</returns>
        public EnemyStats[] GetClosestEnemies(Transform _target, float _maxRange, float _minRange = 0)
        {
            //Want the info out of this function to be static
            //Start by adding them all then return the converted array []
            List<EnemyStats> closeEnemies = new List<EnemyStats>();

            foreach (EnemyStats enemy in aliveEnemies)
            {
                //Detects if the enemy is within range, if so, add to the list
                float distance = Vector3.Distance(enemy.transform.position, _target.position); //------
                if (distance < _maxRange && distance > _minRange)
                {
                    closeEnemies.Add(enemy);
                }
            }
            
            //Convert list to array
            return closeEnemies.ToArray();
        }
    }
}
