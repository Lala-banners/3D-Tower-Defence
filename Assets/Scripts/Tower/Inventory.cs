using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefence.Enemies;
using TowerDefence.Towers;

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
    public Button[] turretButtons;
    public int currentTurret = -1; //current turret being used
    public int maxTurretCount = 10; //The maximum amount of turrets that can be used from inventory


    public GameObject currentTurretObject = null;

    public int money = 100; //starting amount of money
    private int maxMoney = 0; //So money doesnt go below 0
    public Text moneyText;
    public int laserOneCost = 10;
    public int laserTwoCost = 20;
    public int laserThreeCost = 30;
    private TurretHandler[] turretHandlers;

    private void Start()
    {
        turretHandlers = new TurretHandler[turrets.Length];
        for (int i = 0; i < turrets.Length; i++)
        {
            TurretHandler handler = turrets[i].GetComponent<TurretHandler>();
            turretHandlers[i] = handler;
        }
    }

    private void Update()
    {
        moneyText.text = "Money: " + money.ToString();
        for (int i = 0; i < turretButtons.Length; i++)
        {
            Button button = turretButtons[i];
            TurretHandler turret = turretHandlers[i];
            button.interactable = turret.cost < money;
        }
    }

    EnemyStats enemy;
    public void UseLaserOne()
    {
        currentTurretObject = turrets[0];
        currentTurret = 0;

        money = money - laserOneCost;

        if (money < laserOneCost)
        {
            money = maxMoney;
            Debug.Log("No more money");
        }
    }

    public void UseLaserTwo()
    {
        currentTurretObject = turrets[1];
        currentTurret = 1;

        money = money - laserTwoCost;

        if (money < laserTwoCost)
        {
            money = maxMoney;
            Debug.Log("No more money");
        }
    }


    public void UseLaserThree()
    {
        currentTurretObject = turrets[2];
        currentTurret = 2;

        money = money - laserThreeCost;

        if (money < laserThreeCost)
        {
            money = maxMoney;
            Debug.Log("No more money");
        }
    }
}
