using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Enemies;
using TowerDefence.Managers;

public class Win : MonoBehaviour
{
    public GameObject winPanel;
    [SerializeField] private EnemyStats stats;
    public void WinGame()
    {
        //If current number of killed enemies is greater or equal to the max (500)
        if (EnemyManager.Instance.currentGraveyardCapacity >= stats.maxEnemy)
        {
            //Win the game
            winPanel.SetActive(true);
            Time.timeScale = 0;
            print("You Won!");
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
    }
}
