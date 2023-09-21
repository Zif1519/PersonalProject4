using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_SelectMenu : MonoBehaviour
{
    [SerializeField] private UI_Manager uiManager;
    void Start()
    {
        gameObject.SetActive(false);
        uiManager.OnViewStateChanged += OnViewStateChanged;
    }

    public void OnViewStateChanged(VIEWSTATE newViewState)
    {
        if (newViewState == VIEWSTATE.MAIN)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
