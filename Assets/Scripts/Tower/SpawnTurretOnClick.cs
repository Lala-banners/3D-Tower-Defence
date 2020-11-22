using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTurretOnClick : MonoBehaviour
{
    public Inventory inv;
    Ray ray; //create the ray
    RaycastHit hit; //creating the raycast hit

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
                bool nullStuff = inv.totalTurrets[0] < inv.maxTurretCount && inv.currentTurretObject != null;

                if (nullStuff)
                {
                    //Creates a prefab wherever user clicks
                    Instantiate(inv.currentTurretObject, hit.point, Quaternion.identity);
                    inv.totalTurrets[inv.currentTurret]++;
                    inv.money--; //take money
                }
            }
        }
    }
}
