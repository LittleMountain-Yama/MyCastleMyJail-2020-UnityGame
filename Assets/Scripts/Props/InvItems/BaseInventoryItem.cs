using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInventoryItem : BaseInteractable
{
    [SerializeField] string itemName; 

    void Awake()
    {
        offset = transform.forward + transform.up * 3;
    }

    public override void Trigger()
    {
        AudioSystem.PlaySound(AudioSystem.SoundType.Item_PickUp, this.transform);
        EventManager.TriggerEvent(EventManager.EventsType.Event_Inventory_AddItem, itemName);
        gameObject.SetActive(false);
    }
}
