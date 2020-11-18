using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private GameObject testEnemy;
    [SerializeField]
    Transform turret;

    private void Update()
    {
        turret.LookAt(testEnemy.transform);
    }
}
