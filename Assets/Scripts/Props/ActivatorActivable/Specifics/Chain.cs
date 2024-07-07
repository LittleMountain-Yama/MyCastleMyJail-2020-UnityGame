using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : BaseInteractable
{
    [SerializeField] GameObject blocker;
    [SerializeField] string text;

    #region SetUp
    protected override void Start()
    {
        base.Start();
        isUsable = false;
    }

    public override void OnInteractable()
    {
        base.OnInteractable();

        EventManager.TriggerEvent(EventManager.EventsType.Event_Text_ChangeText, text, 1.5f);
    }

    protected override void LightStuff()
    {
        base.LightStuff();
    }
    #endregion

    #region Interactable
    public override void Trigger()
    {
        if (!isUsable)
        {
            RequestItem();
        }
        else
        {
            AudioSystem.PlaySound(AudioSystem.SoundType.Chain_Break, this.transform);
            blocker.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    void RequestItem()
    {
        if (Inventory.Instance.GetInventory("ChainBreaker", true))
        {
            isUsable = true;
        }
    }
    #endregion
}
