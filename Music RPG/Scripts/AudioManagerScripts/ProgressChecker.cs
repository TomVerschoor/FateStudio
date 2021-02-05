using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressChecker : MonoBehaviour
{
    public UnityEvent OnEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ExecuteOnEnter(other);
        }
    }

    protected virtual void ExecuteOnEnter(Collider other)
    {
        OnEnter.Invoke();
    }
}
