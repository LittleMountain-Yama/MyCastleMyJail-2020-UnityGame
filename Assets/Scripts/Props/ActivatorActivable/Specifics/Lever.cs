using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : BaseInteractable, IActivator
{
    [SerializeField] protected GameObject handle;
    [SerializeField] protected GameObject actPos, deactPos;

    protected DelegateUpdate triggerDelegate;

    protected float limit = 2.5f;

    #region SetUp
    protected virtual void Awake()
    {
        triggerDelegate += Trigger;
        offset = this.transform.forward;
    }

    protected override void LightStuff()
    {
        base.LightStuff();
    }
    #endregion

    #region Interactable
    public override void Trigger()
    {
        if (!isUsable) return;

        SendSignal();
        Handling();
    }

    protected void Handling()
    {
        if (!activated)
        {
            if (handle != null && actPos != null) handle.transform.position = actPos.transform.position;
        }
        else
        {
            if (handle != null && deactPos != null) handle.transform.position = deactPos.transform.position;
        }

        activated = !activated;
        isUsable = false;
        triggerDelegate -= Trigger;

        AudioSystem.PlaySound(AudioSystem.SoundType.Lever_Activated, this.transform);

        StartCoroutine(Counter());
    }

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
    #endregion

    protected IEnumerator Counter()
    {
        yield return new WaitForSeconds(limit);

        triggerDelegate += Trigger;
        isUsable = true;        
    }   
}
