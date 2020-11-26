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
        //If current number of killed enemies is greater or equal to the max (150)
        if (EnemyManager.Instance.currentGraveyardCapacity >= stats.maxEnemy)
        {
            //You win! Stop the game and win panel appears
            winPanel.SetActive(true);
            Time.timeScale = 0;
            //print("You Won!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
    }
}
