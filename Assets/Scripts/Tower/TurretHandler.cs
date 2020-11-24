using UnityEngine; //namespace
using TowerDefence.Enemies;
using TowerDefence.Managers;

//namespaces - categories of things
//Towers will have access to TowerDefence.Towers namespace
namespace TowerDefence.Towers
{
    public abstract class TurretHandler : MonoBehaviour
    {
        #region PROPERTIES
        public string TowerName // The public accessor for the towerName variable.
        {
            get => towerName; //Properties
        }

        public string Description
        {
            get => description; // The public accessor for the description variable.
        }

        public int Cost // The public accessor for the cost variable.
        {
            get => cost;
        }

        /// <summary>
        /// The Maximum range the tower can reach based on its level
        /// </summary>
        private float MaximumRange
        {
            get
            {
                //Multiplying is faster than dividing
                return maximumRange * (level * 0.5f + 0.5f);
            }
        }

        /// <summary>
        /// The amount of damage the tower does, multiplied by its level
        /// </summary>
        public float Damage
        {
            get
            {
                return damage * (level * 0.5f + 0.5f);
            }
        }

        /// <summary>
        /// The enemy the turret is currently targeting, if no enemy is targeted, this is null.
        /// </summary>
        protected Enemy TargetedEnemy
        {
            get
            {
                return target;
            }
        }

        #endregion

        #region VARIABLES
        [Header("General Stats")]
        [SerializeField] //Makes variables able to be modified in Inspector and saves changes made
        private string towerName = "";
        [SerializeField, TextArea] //TextArea turns string into box
        private string description = "";
        [SerializeField, Range(1, 10)]
        private int cost = 1;

        [Header("Attack Stats")] //Headers are displayed in Inspector as bold headings
        [SerializeField, Min(0.1f)]
        private float damage = 1;
        [SerializeField, Min(10f)]
        public float shootRange = 10f;
        [SerializeField] public float maximumRange = 20f;
        [SerializeField, Min(0.1f)]
        protected float fireRate = 0.1f;

        public Transform turret;
        private int level = 1;
        private float xp = 0;
        //target the TurretHandler is attacking
        [SerializeField] private Enemy target = null;

        private float currentTime = 0;

        public GameObject bulletPrefab;
        public Transform firePoint;

        #endregion



        private void OnValidate() //OnValidate runs whenever a variable is changed within the Inspector of this class
        {
            //Mathf = A collection of common math functions
            //Mathf.Clamp = Clamps the given value between the given minimum float and maximum float values. Returns the given value if it is within the min and max range
            maximumRange = Mathf.Clamp(maximumRange, shootRange + 1, float.MaxValue);
        }

        private void OnDrawGizmosSelected() //OnDrawGizmosSelected draws helpful visuals only when the object is selected. Gizmos are visual debugs we can draw eg sphere, cube, lines, rays, meshes
        {
            //Draw a mostly transparent red sphere indicating the shooting range
            Gizmos.color = new Color(1, 0, 0, 0.25f);
            Gizmos.DrawWireSphere(transform.position, shootRange);

            //Draw a mostly transparent blue sphere indicating the maximum range
            Gizmos.color = new Color(0, 0, 1, 0.25f);
            Gizmos.DrawWireSphere(transform.position, MaximumRange);
        }

        //protected abstract void RenderAttackVisuals();
        
        //Function for making the turret aim at enemies
        protected void Aim()
        {
            if (target != null)
            {
                turret.LookAt(TargetedEnemy.transform);
            }
        }

        //Fire() is only handling firing 
        public void Fire()
        {
            //Make sure there is actually something to target, if there is, damage it
            if (target != null)
            {
                target.Damage(20f); 

                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //spawn bullet at fire point
                
            }
        }

        private void FireWhenReady()
        {
            //Make sure there is actually a target
            if (target != null)
            {
                // If the timer is less than the fireRate, add the deltaTime
                // to make sure the turret fires in real time
                if (currentTime < fireRate)
                {
                    currentTime += Time.deltaTime;
                }
                else
                {
                    // Reset the current time and fire.
                    currentTime = 0;

                    Fire();
                }
            }
        }

        private void Target()
        {
            //Get enemy within range
            Enemy[] closeEnemies = EnemyManager.instance.GetClosestEnemies(transform, maximumRange); //-------

            //Call get closest enemy (partitioning)
            target = GetClosestEnemy(closeEnemies);
        }

        // _enemies is array of enemies within range
        //loop through every enemy on the list
        private Enemy GetClosestEnemy(Enemy[] _enemies)
        {
            float closestDist = float.MaxValue;
            Enemy closest = null;

            foreach (Enemy enemy in _enemies)
            {
                //Distance between us and the enemy
                float distToEnemy = Vector3.Distance(enemy.transform.position, transform.position);

                //If the enemy is closer than the current, make it the closest
                // and the distance the new closest distance
                if (distToEnemy < closestDist)
                {
                    //finding out which enemy is closest to us
                    closestDist = distToEnemy;
                    closest = enemy;
                }
            }
            return closest;
        }

        
        protected virtual void Update()
        {
            Target(); //------
            FireWhenReady();
            Aim();
        }
    }
}

