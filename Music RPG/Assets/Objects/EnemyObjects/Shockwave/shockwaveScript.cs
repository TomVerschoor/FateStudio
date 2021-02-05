using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwaveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, 5);
        bigger();
    }

    private void bigger()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.1f, gameObject.transform.localScale.y + 0.1f, gameObject.transform.localScale.z);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("COL");
        if (col.gameObject.name == "PlayerBattle")
        {
            //ArenaController.lives -= 1;
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Synthia/Hurt/Hurt SFX", GetComponent<Transform>().position);
            //Destroy(gameObject);
            Debug.Log("Shockwave hit! Player:"); //+ArenaController.lives
        }
        //if (col.collider.gameObject.name != "EnemyBattle")
        //{
        //    Destroy(gameObject);
        //}
    }
}
