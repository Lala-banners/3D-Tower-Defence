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
    public class Enemy : MonoBehaviour
    {
        #region Enemy Path finding
        public int index = 0;
        public GameObject[] enemyPaths;
        public float minDistance = 0.5f;
        public EnemyManager enemyMan;
        public CoreHealth coreHealth;
        #endregion

        //[System.Serializable]
        //public class DeathEvent : UnityEvent<Enemy> { }
        public float XP { get { return xp; } }//Get xp and return amount (This is a property).
        public int Money { get { return money; } } //Get money and return amount (This is a property).

        [Header("General Enemy Stats")]
        [SerializeField, Tooltip("How fast the enemy will move within the game")]
        private float speed = 1;
        
        [Header("Health")]
        public Slider healthBar;
        [SerializeField, Tooltip("How much damage the enemy can take before dying")]
        public float enemyHealth = 100;

        [Header("Rewards")]
        [SerializeField, Tooltip("Amount of experience the killing tower will gain from killing enemy")]
        private float xp = 1;
        [SerializeField, Tooltip("Amount of money player will gain upon killing the enemy")]
        private int money = 1;


        private void Start()
        {
            coreHealth = FindObjectOfType<CoreHealth>();

            if(coreHealth == null)
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
                print("Enemies are dying!");
                Die();
            }
        }

        /// <summary>
        /// Handles damage of the enemy and if below or equal to 0, calls Die()
        /// </summary>
        public void Damage(float _damage)
        {
            enemyHealth -= _damage;
            if (enemyHealth <= 0)
            {
                enemyHealth = enemyHealth - _damage;
                healthBar.value = enemyHealth;
                Die();
            }
        }

        private void Die()
        {
            Destroy(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            EnemyFollowPath();
        }
    }
}
