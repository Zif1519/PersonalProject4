using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] public Transform _sv_Content;
    [SerializeField] public Sprite[] _backgroundSprites;
    [SerializeField] public GameObject _slotPrefab;
    [SerializeField] public List<SlotUI> _currentSlots;


    public void SetInventory(InventoryData newinventoryData)
    {
        ClearSlots();
        for (int i = 0; i < newinventoryData._slotCount; i++)
        {
            var slotObject = FindNullSlot();
            SlotUI slotUI = slotObject.GetComponent<SlotUI>();
            
            if (i < newinventoryData._items.Count)
            {
                slotUI.SetItemSlot(newinventoryData._items[i]);
            }
            else
            {
                slotUI.SetEmptySlot();
            }
            _currentSlots.Add(slotUI);
        }
    }

    public SlotUI FindNullSlot() 
    { 
        foreach(var slot in _currentSlots)
        {
            if (slot._isEmpty == true && !slot._isActive)
            {
                slot.gameObject.SetActive(true);
                return slot;
            }
        }
        var slotObject = Instantiate(_slotPrefab, _sv_Content);
        return slotObject.GetComponent<SlotUI>();
    }

    public void ClearSlots()
    {
        for (int i = 0; i < _currentSlots.Count; i++)
        {
            _currentSlots[i].ClearSlot();
            _currentSlots[i].gameObject.SetActive(false);
        }
    }
}
