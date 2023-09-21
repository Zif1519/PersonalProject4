using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemName", menuName = "ScriptableObject/ItemData", order = 0)]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private int _itemDataID;
    [SerializeField] private string _itemBaseName;
    [SerializeField] private string _itemBaseDescription;

    [Header("Data")]
    [SerializeField] private int _itemBasePrice;
    [SerializeField] private ITEMTYPE _itemBaseType;
    [SerializeField] private ITEMRARITY _itemBaseRarity;
    //[SerializeField] private StatusData _itemStatusBuff;

    [Header("UI")]
    [SerializeField] private Sprite _itemSprite;
    // ����Ŭ������ ��

    //[Header("Stacking")]
    //[SerializeField] private bool _isStackable;
    //[SerializeField] private int _maxStackAmount;

    public int ItemDataID => _itemDataID;
    public string ItemBaseName => _itemBaseName;
    public string ItemBaseDescription => _itemBaseDescription;

    public int ItemPrice => _itemBasePrice;
    public ITEMTYPE ItemBaseType => _itemBaseType;
    public ITEMRARITY ItemBaseRarity => _itemBaseRarity;
    
    //public StatusData ItemStatusBuff => _itemStatusBuff;

    public Sprite ItemSprite => _itemSprite;
    // ����Ŭ������ ��





    //public bool IsStackable => _isStackable;
    //public int MaxStackAmount => _maxStackAmount;

}

