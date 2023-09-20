using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusData
{
    [SerializeField] public int _Attack;
    [SerializeField] public int _Defence;
    [SerializeField] public int _Health;
    [SerializeField] public int _Critical;
    [SerializeField] public int _Dodge;
    [SerializeField] public int _Speed;
    
    public StatusData() 
    { 
        _Attack = 0;
        _Defence = 0;
        _Health = 0;
        _Critical = 0;
        _Dodge = 0;
        _Speed = 0;
    }
}
