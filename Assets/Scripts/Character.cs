using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public event Action<CharacterData> OnCharacterDataChanged;

    
    public CharacterData _currentCharacterData;


    public void CallEventCharacterDataChanged()
    {
        OnCharacterDataChanged?.Invoke(_currentCharacterData);
    }
    


}
