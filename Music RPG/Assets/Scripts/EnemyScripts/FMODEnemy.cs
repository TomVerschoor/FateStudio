using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEnemy : MonoBehaviour
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
        RaycastHit hit; ;

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
                material = 1f;
            }
        }
    }

    void PlayEnemyFootstepsEvent(string path)
    {
        FMOD.Studio.EventInstance footsteps = FMODUnity.RuntimeManager.CreateInstance(path);

        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(footsteps, transform, GetComponentInParent<Rigidbody>());
        footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        footsteps.setParameterByName("Material", material);
        footsteps.start();
        footsteps.release();
    }
}
