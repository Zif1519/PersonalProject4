using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VIEWSTATE { MAIN = 0, STATUS, INVENTORY }
public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;

    public VIEWSTATE _CurrentViewState = VIEWSTATE.MAIN;
    public event Action<StatusData> OnStatusChanged;
    public event Action<InventoryData> OnInventoryDataChanged;
    public event Action<VIEWSTATE> OnViewStateChanged;
    public event Action<CharacterData> OnCharacterDataChanged;

    public Sprite[] _item_BackgroundSprites;
    //public Sprite[] _item_frameSprites;

    private void Awake()
    {
        Instance = this;
    }


    public void CallEventStatusChanged(StatusData newStatusData)
    {
        OnStatusChanged?.Invoke(newStatusData);
    }
    public void CallEventInventoryChanged(InventoryData newInventoryData)
    {
        OnInventoryDataChanged?.Invoke(newInventoryData);
    }
    public void CallEventViewStateChanged(VIEWSTATE newViewState)
    {
        OnViewStateChanged?.Invoke(newViewState);
    }
    public void CallEventCharacterDataChanged(CharacterData newCharacterData)
    {
        OnCharacterDataChanged?.Invoke(newCharacterData);
    }


    public void SetViewState_Main()
    {
        _CurrentViewState = VIEWSTATE.MAIN;
        CallEventViewStateChanged(VIEWSTATE.MAIN);
    }
    public void SetViewState_Status()
    {
        _CurrentViewState = VIEWSTATE.STATUS;
        CallEventViewStateChanged(VIEWSTATE.STATUS);
    }

    public void SetViewState_Inventory()
    {
        _CurrentViewState = VIEWSTATE.INVENTORY;
        CallEventViewStateChanged(VIEWSTATE.INVENTORY);
    }

    public void SetMainCharacter(Character newCharacter)
    {
        newCharacter.OnCharacterDataChanged += OnCharacterChanged;
    }
    public void UnsetMainCharacter(Character oldCharacter)
    {
        oldCharacter.OnCharacterDataChanged -= OnCharacterChanged;
    }
    public void OnCharacterChanged(CharacterData newCharacterData)
    {
        CallEventInventoryChanged(newCharacterData._inventoryData);
        CallEventViewStateChanged(VIEWSTATE.MAIN);
        CallEventStatusChanged(newCharacterData._statusData);
        CallEventCharacterDataChanged(newCharacterData);
    }
}
