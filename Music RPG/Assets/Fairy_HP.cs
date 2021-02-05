using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy_HP : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected");
        if (other.name == "Player")
        {

            {

                Stats.Instance.TakeDamange(-2);
                Destroy(gameObject);
            }

        }
    }
}
