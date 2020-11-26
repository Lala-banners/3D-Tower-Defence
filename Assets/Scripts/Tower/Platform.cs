using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Inventory inv;
    public Transform towerPos;

    public void OnMouseUpAsButton()
    {
        bool nullStuff = inv.totalTurrets[0] < inv.maxTurretCount &&
                    inv.currentTurretObject != null;

        if (nullStuff)
        {
            //Creates a prefab wherever user clicks
            Instantiate(inv.currentTurretObject, towerPos.position, Quaternion.identity);
            inv.totalTurrets[inv.currentTurret]++;
            inv.money.ToString();
        }
    }
}
