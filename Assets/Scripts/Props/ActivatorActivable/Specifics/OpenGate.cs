using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour, IActivable, IUpdate
{
    [SerializeField] bool activated;
    [SerializeField] GameObject startPos, endPos, model;

    protected delegate void DelegateUpdate();
    protected DelegateUpdate updateDelegate;

    protected DelegateUpdate triggerDelegate;

    GameObject targetPos;

    void Awake()
    {
        if(!activated) model.transform.position = startPos.transform.position;
        else model.transform.position = endPos.transform.position;

        triggerDelegate += Trigger;
    }

    public void Trigger()
    {
        if (activated) MoveTowards(startPos);
        else MoveTowards(endPos);
    }

    public void OnUpdate()
    {
        updateDelegate();
    }

    void MoveTowards(GameObject pos)
    {
        activated = !activated;
        targetPos = pos;
        updateDelegate += Move;
        UpdateManager.Instance.AddToUpdate(this);

        triggerDelegate -= Trigger;
    }

    float distance, speed = 0.75f;
    void Move()
    {
        distance = Vector3.Distance(model.transform.position, targetPos.transform.position);

        model.transform.position = Vector3.MoveTowards(model.transform.position, targetPos.transform.position, speed);

        if (distance <= 0)
        {
            triggerDelegate += Trigger;
            UpdateManager.Instance.RemoveFromUpdate(this);
        }
    }
}
