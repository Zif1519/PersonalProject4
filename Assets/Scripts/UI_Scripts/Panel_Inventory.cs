using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Inventory : MonoBehaviour
{
    [SerializeField] private UI_Manager uiManager;
    void Start()
    {
        gameObject.SetActive(false);
        uiManager.OnViewStateChanged += OnViewStateChanged;
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
}
