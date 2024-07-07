using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IActivable, IUpdate
{
    [SerializeField] protected bool deactivable;
    protected bool activated;

    protected delegate void DelegateUpdate();
    protected DelegateUpdate updateDelegate;

    [SerializeField] protected bool isUsable = true;
    LightGhost lightGhost;

    protected virtual void Start()
    {
        lightGhost = null;
        activated = false;
    }

    protected Vector3 offset = Vector3.zero;
    public virtual void OnInteractable()
    {
        if (!isUsable) return;

        LightStuff();
        updateDelegate += CalculateDistance;
        UpdateManager.Instance.AddToUpdate(this);
    }

    protected virtual void LightStuff()
    {
        if (lightGhost == null) lightGhost = LightManager.Instance.CallLight(transform, offset);
    }

    public virtual void Trigger()
    {
        if (activated || !isUsable) return;
            
        activated = true;   
    }

    float distance;
    void CalculateDistance()
    {
        var temp = FindObjectOfType<PlayerController>();

        distance = Vector3.Distance(temp.transform.position, transform.position);

        if(distance >= PlayerValues.Default.interactRadius + 0.5f)
        {
            if (lightGhost != null)
            {
               lightGhost.ReturnLight();
               lightGhost = null;
            }

            UpdateManager.Instance.RemoveFromUpdate(this);
            updateDelegate -= CalculateDistance;
        }
    }

    public void OnUpdate()
    {
        updateDelegate();
    }

}
