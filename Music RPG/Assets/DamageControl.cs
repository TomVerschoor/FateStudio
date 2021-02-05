using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public double damage = 1;
    public static bool damaged = false;

    public void setDamage(double dmg)
    {
        damage = dmg;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("COL");
        if (col.gameObject.name == "Player" && !damaged)
        {
            damaged = true;
            Stats.Instance.TakeDamange(damage);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Synthia/Hurt/Hurt SFX", GetComponent<Transform>().position);
            //Destroy(gameObject);
            //Debug.Log("Shockwave hit! Player:"); //+ArenaController.lives
        }
    }

}
