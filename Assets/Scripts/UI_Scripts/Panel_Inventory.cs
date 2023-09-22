using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Inventory : MonoBehaviour
{
    [SerializeField] private UI_Manager _uiManager;
    [SerializeField] private InventoryUI _inventoryUI;
    void Start()
    {
        gameObject.SetActive(false);
        _uiManager.OnViewStateChanged += OnViewStateChanged;
        _uiManager.OnInventoryDataChanged += OnInventoryDataChanged;
    }

    public void OnViewStateChanged(VIEWSTATE newViewState)
    {
        if (newViewState == VIEWSTATE.INVENTORY)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void OnInventoryDataChanged(InventoryData newInventoryData)
    {
        _inventoryUI.SetInventory(newInventoryData);
    }
}
