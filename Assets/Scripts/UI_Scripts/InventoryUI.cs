using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] public Transform SV_Content;
    [SerializeField] public GameObject SlotPrefab;
    [SerializeField] public InventoryData InventoryData;

    
    public void ResetInventoryView()
    {
        List<Item> items = InventoryData.Items;
        for (int i=0; i < InventoryData.Items.Count; i++)
        {
            var slot = Instantiate(SlotPrefab, SV_Content);
            slot.GetComponent<SlotUI>().InitSlot(items[i]);
        }
    }
}
