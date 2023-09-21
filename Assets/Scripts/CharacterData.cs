using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacter", menuName ="ScriptableObject/CharacterData", order =2)]
[Serializable]
public class CharacterData : ScriptableObject
{
    [SerializeField] public int _characterID;
    [SerializeField] public string _characterName;
    [SerializeField] public string _characterDescription;
    [SerializeField] public int _gold;
    [SerializeField] public int _level;
    [SerializeField] public int _exp;

    [SerializeField] public Sprite _characterSprite;
    [SerializeField] public InventoryData _inventoryData;
}
