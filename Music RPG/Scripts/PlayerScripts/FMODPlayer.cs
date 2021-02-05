using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODPlayer : MonoBehaviour
{
    private float distance = 1.5f;
    private float material;

    void FixedUpdate()
    {
        MaterialCheck();
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Vector3.down * distance, Color.blue);   
    }

    void MaterialCheck()
    {
        RaycastHit hit;;

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Vector3.down, out hit, distance, 1 << 9))
        {
            if (hit.collider.tag == "Material: Stone")
            {
                Debug.Log(hit.collider.name);
                material = 1f;
            }
            else if (hit.collider.tag == "Material: Gravel")
            {
                Debug.Log(hit.collider.name);
                material = 2f;
            }
            else
            {
                material = 0f;
            }
        }
    }

    void PlayFootstepsEvent(string path)
    {
        FMOD.Studio.EventInstance footsteps = FMODUnity.RuntimeManager.CreateInstance(path);

        footsteps.setParameterByName("Material", material);
        footsteps.start();
        footsteps.release();
    }
    
    void PlayAttackSound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path);
    }
}