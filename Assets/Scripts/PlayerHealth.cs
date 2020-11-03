using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable<int>, IKillable
{

    public int maxHealth = 100;
    public static int currentHealth;
    public static bool isAlive;

    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
        
        NoHealth();
    }

    // Changes the healthbar based on the missing health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    // When the player dies
    public void OnEmptyBar()
    {
        isAlive = false;
        Debug.Log(isAlive);
    }
    
    private void OnTriggerEnter(Collider trap)
    {
        if (trap.CompareTag("Trap"))
        {
            TakeDamage(1);
            Debug.Log("yes");
        }
    }

    private void NoHealth()
    {
        if (currentHealth == 0)
        {
            isAlive = false;
        }
    }
}
