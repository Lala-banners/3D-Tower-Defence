using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTurretOnClick : MonoBehaviour
{
    public Inventory inv;
    Ray ray; //create the ray
    RaycastHit hit; //creating the raycast hit
    //public GameObject turretToInstantiate; //the object that will be instantiated is the turret (will change depending on which turret type is being used)
    //public GameObject[] turretSlots;

    // Update is called once per frame
    void Update()
    {
        //Tells ray it will spawn from the center of the camera to the mouse position
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //If mouse button left is down
            if (Input.GetMouseButtonDown(0))
            {
                if (inv.totalTurrets[0] < inv.maxTurretCount)
                {
                    //Creates a prefab wherever user clicks
                    Instantiate(inv.currentTurretObject, hit.point, Quaternion.identity);
                    inv.totalTurrets[inv.currentTurret]++;
          
                }

            }
        }
    }
}
