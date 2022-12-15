using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public In_Menu_Game inMenuGame;
    public GameObject panelGameOver;

    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 1)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        else if (currentHealth == 1)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            inMenuGame.GameOver(panelGameOver);
        }
    }
}
