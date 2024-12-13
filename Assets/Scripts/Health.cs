using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* REUSABLE HEALTH CLASS */
public class Health : MonoBehaviour
{
    public int maxHealth = 10; // default
    public int currentHealth = 10; // default

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    /* CONSTUCTOR */
    public Health(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    /* FUNCTIONS */
    public void TakeDamage(int dmg, GameObject obj)
    {
        currentHealth -= dmg;
        Debug.Log($"CURRENT HEALTH {currentHealth}/10");

        // the hit may be more pts than health left, so health might be -, so <=0
        if (currentHealth <= 0)
        {
            Defeated(obj);
        }
    }

    public void Defeated(GameObject obj)
    {
        Debug.Log(obj.name + "Defeated!");
        Destroy(obj);
    }
}
