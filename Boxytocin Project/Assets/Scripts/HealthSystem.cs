using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int baseHealth = 100;

    public HealthSystem(int health)
    {
        this.health = health;
    }

    public int getHealth()
    {
        return health;
    }

    public void addHealth(int value)
    {
        health += value;
        if(health > baseHealth){
            health = baseHealth;
        }
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

}
