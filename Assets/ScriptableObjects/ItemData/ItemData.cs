using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEMTYPE { WEAPON, SHIELD, HELMET, GLOVES, NECKLACE, BOOTS, ARMOR, RING }
public enum ITEMRARITY { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY }

[CreateAssetMenu(fileName = "ItemName", menuName = "ScriptableObject/ItemData", order = 0)]
public class ItemData : ScriptableObject
{
    [SerializeField] public int _ItemID;
    [SerializeField] public ITEMTYPE _ItemType;
    [SerializeField] public ITEMRARITY _ItemRarity;
    [SerializeField] public string _ItemName;
    [SerializeField] public string _ItemDescription;
    [SerializeField] public StatusData _ItemStatusBuff;

    public ItemData()
    {
        _ItemID = 0;
        _ItemName = "";
        _ItemType = ITEMTYPE.WEAPON;
        _ItemRarity = ITEMRARITY.COMMON;
        _ItemDescription = string.Empty;
        _ItemStatusBuff = new StatusData();
    }
}

