using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{

    public static Item_Manager Instance;
   
    [SerializeField] public GameObject Item_Prefab;
    [SerializeField] public GameObject Inventory_Prefab;




    private void Awake()
    {
        Instance = this;
    }

}
