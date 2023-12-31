using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public enum ITEMTYPE { FOOD, POTION, WEAPON, SHIELD, HELMET, GLOVES, NECKLACE, BOOTS, ARMOR, RING }
public enum ITEMRARITY { NULL=0, COMMON =1, UNCOMMON =2, RARE=3, EPIC =4, LEGENDARY = 5 }

[Serializable]
public class Item
{
    public event Action OnItemDataChanged;

    [SerializeField] private int _itemID;
    [SerializeField] private string _itemName;
    [SerializeField] private ItemData _itemData;
    [SerializeField] private ITEMRARITY _itemRarity;
    [SerializeField] private bool _isEquiped;

    public int ItemID => _itemID;
    public int ItemDataID => _itemData.ItemDataID;
    public string ItemName => _itemName;
    public ITEMTYPE ItemType => _itemData.ItemBaseType;
    public ITEMRARITY ItemRarity => _itemRarity;
    public bool IsEquiped => _isEquiped;
    public Sprite ItemSprite => _itemData.ItemSprite;
    public int ItemPrice 
    { 
        get { return _itemData.ItemPrice * ((int)ItemRarity+1); }
    }
    public Item(ItemData itemData)
    {
        _itemData = itemData;
        _itemID = 0;
        _itemName = itemData.ItemBaseName;
        _itemRarity = itemData.ItemBaseRarity;
    }

    public void SetItemRarity(ITEMRARITY newRarity) 
    { 
        if (newRarity != _itemRarity)
        {
            _itemRarity = newRarity;
        }
    }

    public void CallEventOnItemDataChanged()
    {
        OnItemDataChanged?.Invoke();
    }
}
