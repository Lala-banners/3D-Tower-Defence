using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum TurretTypes
    {
        none,
        laserOne,
        laserTwo,
        laserThree
    }

public class Inventory : MonoBehaviour
{
    public int[] totalTurrets; //Total amount of turrets [3]
    public GameObject[] turrets; //Physical turrets
    public int currentTurret = -1; //how many turrets there are in the inventory
    public int maxTurretCount = 10; //The maximum amount of turrets that can be used from inventory
                                    // public int turretCount = 0; //Count that turrets will be subtracted or added to

    public GameObject currentTurretObject = null;

    //Method for making current turret laser one
    public void UseLaserOne()
    {
       //TurretTypes types = TurretTypes.laserOne;
       //How many turrets you have when taken from inventory
       //currentTurret = types;
            
        currentTurretObject = turrets[0];
        currentTurret = 0;
    }

    public void UseLaserTwo()
    {
        currentTurretObject = turrets[1];
        currentTurret = 1;
    }


    public void UseLaserThree()
    {
        currentTurretObject = turrets[2];
        currentTurret = 2;
    }

    //Spawn turret on map
    //Check if it the correct turret
    //Remove turret[1] from totalTurrets[]
}
