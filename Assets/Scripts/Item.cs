using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public enum ITEMTYPE { FOOD, POTION, WEAPON, SHIELD, HELMET, GLOVES, NECKLACE, BOOTS, ARMOR, RING }
public enum ITEMRARITY { COMMON =0, UNCOMMON =1, RARE=2, EPIC =3, LEGENDARY = 4 }

[Serializable]
public class Item
{
    public event Action OnItemDataChanged;

    [SerializeField] private int _itemID;
    [SerializeField] private string _itemName;
    [SerializeField] private ItemData _itemData;
    [SerializeField] private ITEMRARITY _itemRarity;

    public int ItemID => _itemID;
    public int ItemDataID => _itemData.ItemDataID;
    public string ItemName => _itemName;
    public ITEMTYPE ItemType => _itemData.ItemBaseType;
    public ITEMRARITY ItemRarity => _itemRarity;
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
