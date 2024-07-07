using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : BaseInteractable
{
    [SerializeField] string itemName;

    public override void Trigger()
    {
        base.Trigger();
        AddToInventory();
    }

    void AddToInventory()
    {
        EventManager.TriggerEvent(EventManager.EventsType.Event_Inventory_AddItem, itemName);
        this.gameObject.SetActive(false);
    }
}
