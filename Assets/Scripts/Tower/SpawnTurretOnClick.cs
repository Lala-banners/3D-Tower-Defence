using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTurretOnClick : MonoBehaviour
{
    Ray ray; //create the ray
    RaycastHit hit; //creating the raycast hit
    public GameObject turretToInstantiate; //the object that will be instantiated is the turret
    public Image[] turretSlots;
    //Spawn location set to turret slot
    //Instantiate on click FROM INVENTORY TURRET SLOTS to the grid

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
                //Creates a prefab wherever user clicks
                Instantiate(turretToInstantiate, hit.point, Quaternion.identity);
                //turretToInstantiate.Instantiate<Transform>(hit.point, turretSlots, Quaternion.identity);
            }
        }
    }
}
