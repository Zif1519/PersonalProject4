using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class SlotUI : MonoBehaviour
{
    public bool _isEmpty = true;
    public Item _item;
    public bool _isActive = true;

    [SerializeField] public InventoryUI _inventoryUI;
    [SerializeField] public Sprite[] _backgroundImages;
    [SerializeField] public Image _currentBackground;
    [SerializeField] public Image _currentItemImage;
    [SerializeField] public GameObject _isEquiped;
    [SerializeField] public Button _button;

    public void SetItemSlot(Item newitem)
    {
        _isActive = true;
        _isEmpty = false;
        _item = newitem;
        _currentItemImage.sprite = newitem.ItemSprite;
        _currentBackground.sprite = _backgroundImages[(int)newitem.ItemRarity];
        CheckEquipButton();
    }

    public void SetEmptySlot()
    {
        _isActive = true;
        _isEmpty = true;
        _item = null;
        _currentItemImage.sprite = null;
        _currentBackground.sprite = _backgroundImages[0];
        CheckEquipButton();
    }

    public void ClearSlot()
    {
        _isActive = false;
        _isEmpty =true;
        _item = null;
        _currentBackground.sprite = _backgroundImages[0];
        CheckEquipButton();
        _isEquiped.SetActive(false);
    }

    public void CheckEquipButton()
    {
        if(_isActive && !_isEmpty && _item?.ItemType == ITEMTYPE.WEAPON)
        {
            _button.gameObject.SetActive(true);
        }else
        {
            _button.gameObject.SetActive(false);
        }
    }
    public void OnClickEquipButton()
    {
        _isEquiped.SetActive(true);
    }
}
