using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100f;
    private float health;


    void Start()
    {
        health = maxHealth;
    }

    public float getHealth()
    {
        return health;
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
            die();
    }

    public void heal(float amount = 0)
    {
        if (amount == 0)
            amount = maxHealth;
        health += amount;

        if (health > maxHealth)
            health = maxHealth;
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
