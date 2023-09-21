using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum INVENTORYTYPE { CHARACTERINVENTORY = 0, EQUIPMENT, SHOP }

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObject/InventoryData", order = 1)]
[Serializable]
public class InventoryData : ScriptableObject
{
    [SerializeField] public int _inventoryID;
    [SerializeField] public string _inventoryName;
    [SerializeField] public string _inventoryDescription;
    [Header("Inventory Setting")]
    [SerializeField] public INVENTORYTYPE _inventoryType;
    [SerializeField] public int _slotSize;

    [SerializeField] public List<Item> _items;
    

    public InventoryData()
    {
        _inventoryID = 0;
        _inventoryName = "";
        _inventoryDescription = "";
        _inventoryType = INVENTORYTYPE.CHARACTERINVENTORY;
        _slotSize = 9;

        _items = new List<Item>();
    }
}
