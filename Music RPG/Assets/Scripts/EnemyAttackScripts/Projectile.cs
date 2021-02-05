using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.name == "Player")
        {
            //Stats.Instance.TakeDamange(1);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Synthia/Hurt/Hurt SFX", GetComponent<Transform>().position);
            Destroy(gameObject);
            //Debug.Log("Ranged hit! Player:" + ArenaController.lives);
        }
        if (col.collider.gameObject.name != "EnemyBattle")
        {
            //Destroy(gameObject);
        }
    }
}
