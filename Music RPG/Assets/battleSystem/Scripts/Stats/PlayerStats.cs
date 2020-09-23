using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Awake()
    {
        initiate(100);
    }

    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("enemy");
    }
}
