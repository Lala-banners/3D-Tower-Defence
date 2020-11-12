using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    #region Variables
    private float maxHealth = 100;
    public Slider healthSlider;
    private float currentHealth;
    #endregion


    // Start is called before the first frame update
    void Start()
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
            TakeDamage(10f);
        }

        TowerDefeated();
    }

    public void TakeDamage(float Damage)
    {
        currentHealth = currentHealth - Damage;
        healthSlider.value = currentHealth;
    }

    public void TowerDefeated()
    {
        if(currentHealth == 0)
        {
            print("Tower has been defeated");
        }
    }

}
