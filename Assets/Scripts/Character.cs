using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public event Action<CharacterData> OnCharacterDataChanged;
    public event Action<InventoryData> OnInventoryDataChanged;
    public event Action<InventoryData> OnEquipmentDataChanged;
    public event Action<StatusData> OnStatusDataChanged;

    [SerializeField] private CharacterData _currentCharacterData;
    [SerializeField] SpriteRenderer _currentSpriteRenderer;

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


    private void Start()
    {
        UI_Manager.Instance.OnCharacterDataChanged += ChangeCharacterSprite;
        ChangeCharacterSprite(_currentCharacterData);
    }
    private void OnDestroy()
    {
        UI_Manager.Instance.OnCharacterDataChanged -= ChangeCharacterSprite;
    }

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

    public void ChangeCharacterSprite(CharacterData newData)
    {
        _currentSpriteRenderer.sprite = newData._characterSprite;
    }
}
