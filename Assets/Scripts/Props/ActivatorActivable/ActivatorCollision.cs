using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorCollision : BaseActivator
{
    [SerializeField] MonoBehaviour triggererObject;
    [SerializeField] bool activateOnce;

    protected delegate void ActivableDelegate();
    protected ActivableDelegate actDelegate;

    private void Awake()
    {
        actDelegate = SendSignal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var col = collision.gameObject.GetComponent<MonoBehaviour>();

        if (col == triggererObject)
        {
            actDelegate();

            if (activateOnce) actDelegate -= SendSignal;
        }
    } 
}
