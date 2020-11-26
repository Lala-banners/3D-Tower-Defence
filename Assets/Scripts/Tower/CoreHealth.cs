using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHealth : MonoBehaviour
{
    #region Variables
    private float maxHealth = 100;
    public Slider healthSlider;
    public float currentHealth;
    public GameObject gameOver;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        HealthBar();
    }

    private void Update()
    {
        print(Time.timeScale);
    }
    public void HealthBar()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void TakeDamage(float Damage)
    {
        if (currentHealth == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            Win.isGameOver = true;
            //print("Tower has been defeated");
        }

        //update health bar
        currentHealth = currentHealth - Damage;
        healthSlider.value = currentHealth;
    }
}


