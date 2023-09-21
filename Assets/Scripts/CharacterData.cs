using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacter", menuName ="ScriptableObject/CharacterData", order =2)]
[Serializable]
public class CharacterData : ScriptableObject
{
    [SerializeField] public int CharacterID;
    [SerializeField] public string CharacterName;
    [SerializeField] public string CharacterDescription;

    

}
