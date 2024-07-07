using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoHandleLever : Lever
{
    #region SetUp
    protected override void Awake()
    {
        base.Awake();
        isUsable = false;
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
            SendSignal();
            Handling();
        }
    }

    void RequestItem()
    {
        if(Inventory.Instance.GetInventory("Handle_PuzzleGates", true))
        {
            isUsable = true;
            handle.gameObject.SetActive(true);
        }
    }
    #endregion

}
