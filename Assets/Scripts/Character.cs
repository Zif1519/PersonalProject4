using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event Action<CharacterData> OnCharacterDataChanged;
    public event Action<InventoryData> OnInventoryDataChanged;
    public event Action<InventoryData> OnEquipmentDataChanged;
    public event Action<StatusData> OnStatusDataChanged;

    private void Start()
    {
    }

    [SerializeField] private CharacterData _currentCharacterData;

    public CharacterData CharacterData 
    { 
        get { return _currentCharacterData; } 
        private set 
        { 
            if (_currentCharacterData != value)
            {
                _currentCharacterData = value;
                CallEventOnCharacterDataChanged();
                CallEventOnEquipmentDataChanged();
                CallEventOnStatusDataChanged();
                CallEventOnInventoryDataChanged();
            }
        }
    }
    public InventoryData InventoryData => _currentCharacterData._inventoryData;
    public InventoryData EquipmentData => _currentCharacterData._equipmentData;
    public StatusData StatusData => _currentCharacterData._statusData; 
   
    public void CallEventOnCharacterDataChanged()
    {
        OnCharacterDataChanged?.Invoke(CharacterData);
    }
    public void CallEventOnInventoryDataChanged()
    {
        OnInventoryDataChanged?.Invoke(InventoryData);
    }
    public void CallEventOnEquipmentDataChanged()
    {
        OnEquipmentDataChanged?.Invoke(EquipmentData);
    }
    public void CallEventOnStatusDataChanged()
    {
        OnStatusDataChanged?.Invoke(StatusData);
    }
    public void SetCharacterData(CharacterData newData)
    {
        CharacterData = newData;
    }
}
