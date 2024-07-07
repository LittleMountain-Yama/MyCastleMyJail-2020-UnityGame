using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<string> _inventory = new List<string>();
    public List<string> items { get { return _inventory; } }

    static Inventory _instance;
    public static Inventory Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Inventory_AddItem, AddToInventory);
    }

    void AddToInventory(params object[] param)
    {
        _inventory.Add((string)param[0]);
    }

    public bool GetInventory(string item, bool delete = false)
    {
        var temp = _inventory.Contains(item);

        if(temp) 
        {
            if(delete) _inventory.Remove(item);

            return true;            
        }            
        else return false;
    }
}
