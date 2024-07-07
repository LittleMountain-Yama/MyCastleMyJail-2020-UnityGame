using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseActivator : MonoBehaviour, IActivator
{
    [SerializeField] protected List<GameObject> containers = new List<GameObject>();

    public void SendSignal()
    {
        if (containers.Count <= 0) return;

        foreach (GameObject container in containers)
        {
            if (container == null) return;
            var activable = container.GetComponent<IActivable>();
            if (activable != null) activable.Trigger();
        }        
    }
}
