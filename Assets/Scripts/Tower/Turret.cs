using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret Stats")]
    private string turretName = "";
    [TextArea]
    private string turretDescription = "";

    [Header("Attack Stats")]
    public float damage;
    [SerializeField, Min(5f)]
    private float minRange;
    [SerializeField]
    private float maxRange = 10f;
    protected float fireRate = 1f;

    [Header("Experience Stats")]
    [SerializeField, Range(2, 5)]
    private int maxLevel = 3;
    [SerializeField, Min(1)]
    private float requiredExp = 5;
    [SerializeField]
    private float expScaler = 1; //Multiply exp gained when turret levels up after killing enemies

    private int level = 1;
    private int experience = 0;

    //Make range of turret for min and max range before firing at enemies
    private void OnDrawGizmos()
    {
        //Draw red sphere for min range
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, minRange);

        //Draw blue sphere for max range
        Gizmos.color = new Color(0, 0, 1, 0.25f);
        Gizmos.DrawSphere(transform.position, maxRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
