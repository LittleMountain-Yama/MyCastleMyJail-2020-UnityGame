using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : BaseInteractable
{
    protected bool requirementsMet;
    [SerializeField] protected string itemName;

    protected override void Start()
    {
        base.Start();
        requirementsMet = false;
    }

    public override void Trigger()
    {
        TryToOpen();
    }

    protected void TryToOpen()
    {
        CheckRequirements();

        if (!requirementsMet) return;

        if (!activated)
        {
            activated = true;
            Activate();
        }
        else
        {
            if (!deactivable) return;

            activated = false;
            Deactivate();
        }
    }

    protected void CheckRequirements()
    {
        bool itemCheck = Inventory.Instance.GetInventory(itemName);

        requirementsMet = itemCheck;
    }

    protected virtual void Activate() { }

    protected virtual void Deactivate() { }
}
