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

    public void HealthBar()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TakeDamage(10f);
        }

        //TowerDefeated();
    }

    public void TakeDamage(float Damage)
    {
        if (currentHealth == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            print("Tower has been defeated");
        }
        else
        {
            Time.timeScale = 1;
            gameOver.SetActive(false);
        }

        //update health bar
        currentHealth = currentHealth - Damage;
        healthSlider.value = currentHealth;
    }
    }


