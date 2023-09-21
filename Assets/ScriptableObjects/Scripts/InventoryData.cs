using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum INVENTORYTYPE { CHARACTERINVENTORY = 0, EQUIPMENT, SHOP }

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObject/InventoryData", order = 1)]
[Serializable]
public class InventoryData : ScriptableObject
{
    [SerializeField] public int InventoryID;
    [SerializeField] public string InventoryName;
    [SerializeField] public string InventoryDescription;
    [Header("Inventory Setting")]
    [SerializeField] public INVENTORYTYPE InventoryType;
    [SerializeField] public int SlotSize;

    [SerializeField] public List<Item> Items;
    

    public InventoryData()
    {
        InventoryID = 0;
        InventoryName = "";
        InventoryDescription = "";
        InventoryType = INVENTORYTYPE.CHARACTERINVENTORY;
        SlotSize = 9;

        Items = new List<Item>();
    }
}
