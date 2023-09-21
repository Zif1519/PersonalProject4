using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class SlotUI : MonoBehaviour
{
    public bool _isEmpty = true;
   // public int _itemCount = 0;
    public Item item;

    [Header("Need to Connect")]
    [SerializeField] private Image _backgroundImage;
    //[SerializeField] private Image _frameImage;
    [SerializeField] private Image _itemImage;
    public void InitSlot(Item newitem)
    {
        _isEmpty = false;
        item = newitem;
        newitem.OnItemDataChanged -= SetItemSlot;
        newitem.OnItemDataChanged += SetItemSlot; 
    }

    private void OnDisable()
    {
        item.OnItemDataChanged -= SetItemSlot;
    }
    public void SetItemSlot()
    {
        _backgroundImage.sprite = UI_Manager.Instance._item_BackgroundSprites[(int)item.ItemRarity];
       // _frameImage.sprite = UI_Manager.Instance._item_frameSprites[(int)item.ItemRarity];
    }
}
