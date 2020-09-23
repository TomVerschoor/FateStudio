using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHP;
    public int currentHP { get; private set; }

    public Stat danage;

    public void initiate(int maxHP)
    {
        this.maxHP = maxHP;
        currentHP = maxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
    }
}
