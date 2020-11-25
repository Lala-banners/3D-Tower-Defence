using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TowerDefence.Towers;
using TowerDefence.Managers;
using UnityEngine.Events; //A zero argument persistent callback that can be saved with the Scene.

//namespaces - categories of things
//Enemies will have access to TowerDefence enemies namespace
namespace TowerDefence.Enemies
{
    public class EnemyStats : MonoBehaviour
    {
        #region Enemy Path finding
        public int index = 0;
        public GameObject[] enemyPaths;
        public float minDistance = 0.5f;
        public EnemyManager enemyMan;
        public CoreHealth coreHealth;
        #endregion

        [Header("General Enemy Stats")]
        [SerializeField, Tooltip("How fast the enemy will move within the game")]
        private float speed = 1;
        public int maxEnemy = 100; //max amount of enemies until player wins
      
        [Header("Health")]
        public Slider healthBar;
        [SerializeField, Tooltip("How much damage the enemy can take before dying")]
        public float enemyHealth = 100;
        public float maxHealth;

        [Header("Rewards")]
        [SerializeField, Tooltip("Amount of money player will gain upon killing the enemy")]
        public int worth = 15; //worth of enemy


        private void Start()
        {
            EnemyHealthBar();
            healthBar.maxValue = maxHealth;

            coreHealth = FindObjectOfType<CoreHealth>();

            if (coreHealth == null)
            {
                Debug.LogError("Could not find coreHealth for enemy");
            }
        }

        void EnemyFollowPath()
        {
            //Make enemy travel the path of the waypoints
            float distance = Vector3.Distance(transform.position, enemyPaths[index].transform.position);
            if (distance < minDistance)
            {
                index++;
            }
            if (index >= enemyPaths.Length)
            {
                index = 0;
            }

            MoveBadGuy(enemyPaths[index].transform.position);
        }

        void MoveBadGuy(Vector3 targetPos) //Make enemies move to the paths
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        //Collide with core to self destruct
        private void OnTriggerEnter(Collider other)
        {
            //if (collision.transform.GetComponent<CoreHealth>() != null)
            if (other.transform.tag == "Core")
            {
                coreHealth.TakeDamage(10f);
                Die();
            }
        }

        /// <summary>
        /// Handles damage of the enemy and if below or equal to 0, calls Die()
        /// </summary>
        public void Damage(float _damage)
        {
            enemyHealth = enemyHealth - _damage;
            EnemyHealthBar();
            if (enemyHealth <= 0)
            {
                Die();
            }
        }

        public void EnemyHealthBar()
        {
            healthBar.value = enemyHealth;
            /*healthBar.maxValue = enemyHealth;
            healthBar.value = enemyHealth;*/
        }

        private void Die()
        {
            //print("Enemies are dying!");
            EnemyManager.Instance.KillEnemy(this);
            //Debug.Log(inv.money.ToString());
        }

        // Update is called once per frame
        void Update()
        {
            EnemyFollowPath();

            /*if(Input.GetKeyDown(KeyCode.Space)) FOR TESTING ENEMY HEALTH
            {
                Damage(10f);
                //print("Enemies are losing health!");
            }*/
        }
    }
}
