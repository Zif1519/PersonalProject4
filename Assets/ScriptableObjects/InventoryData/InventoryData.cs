using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum INVENTORYTYPE { CHARACTERINVENTORY = 0, EQUIPMENT, SHOP }

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObject/InventoryData", order = 1)]
[Serializable]
public class InventoryData : ScriptableObject
{
    [SerializeField] public int _InventoryID;
    [SerializeField] public string _InventoryName;
    [SerializeField] public string _InventoryDescription;
    [Header("Inventory Setting")]
    [SerializeField] public INVENTORYTYPE _InventoryType;
    [SerializeField] public int _SlotSize;

    [SerializeField] List<ItemData> _ItemsData;
    

    public InventoryData()
    {
        _InventoryID = 0;
        _InventoryName = "";
        _InventoryDescription = "";
        _InventoryType = INVENTORYTYPE.CHARACTERINVENTORY;
        _SlotSize = 9;

        _ItemsData = new List<ItemData>();
    }
}
