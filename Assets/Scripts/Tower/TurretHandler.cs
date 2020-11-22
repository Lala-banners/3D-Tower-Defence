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
        /// Calculates the required xp based on the current level
        /// and the experience scaler.
        /// </summary>
        private float RequiredXP
        {
            get //can do any kind of logic, similar to function
            {
                //if the level is equal to 1, simply return the baseRequiredXp
                if (level == 1)
                {
                    return baseRequiredXp; //experience to get to level 1 regardless
                }
                //multiply the level by the experience scaler to get the multiplier
                // for the baseRequiredXp
                return baseRequiredXp * (level * experienceScaler);
            }
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

        [Header("Experience Stats")]
        [SerializeField, Range(2, 5)]
        private int maxLevel = 3;
        [SerializeField, Min(1)]
        private float baseRequiredXp = 5;
        [SerializeField]
        private float experienceScaler = 1; //multiplied(*) by scaler when player levels up


        public Transform turret;
        private int level = 1;
        private float xp = 0;
        //target the TurretHandler is attacking
        [SerializeField] private Enemy target = null;
        /* null (reference to objects) - means nothing.
        * Objects take small amount of memory on a computer and when it's null there is nothing assigned to it (As if it doesn't exist).
        * EG commented line of code.
       */

        private float currentTime = 0;
        #endregion

        private void OnValidate() //OnValidate runs whenever a variable is changed within the Inspector of this class
        {
            //Mathf = A collection of common math functions
            //Mathf.Clamp = Clamps the given value between the given minimum float and maximum float values. Returns the given value if it is within the min and max range
            //maximumRange = Mathf.Clamp(maximumRange, shootRange + 1, float.MaxValue);
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

        //_ differentiates between variable and parameters = problems
        public void AddExperience(Enemy _enemy)
        {
            xp += _enemy.XP; 
            //Check that the level is not maxed out and that we have
            // passed the required experience to level up
            if (level < maxLevel)
            {
                if (xp >= RequiredXP)
                {
                    LevelUp();
                }
            }
        }

        protected abstract void RenderAttackVisuals();
        protected abstract void RenderLevelUpVisuals();
        
        //Function for making the turret aim at enemies
        protected void Aim()
        {
            if (target != null)
            {
                turret.LookAt(TargetedEnemy.transform);
                
            }
            
        }

        public void LevelUp()
        {
            level++; //Add 1 to the level
            xp = 0;

            RenderLevelUpVisuals();
        }

        //Fire() is only handling firing 
        public void Fire()
        {
            //Make sure there is actually something to target, if there is, damage it
            if (target != null)
            {
                //(this) object
                target.Damage(Damage); //Property Damage

                //Update the health bar
                //target.healthBar.value = target.enemyHealth;

                // Render attack visuals  
                RenderAttackVisuals();
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
            Enemy[] closeEnemies = EnemyManager.instance.GetClosestEnemies(transform, shootRange);

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
            Target();
            FireWhenReady();
            Aim();
        }
    }
}

