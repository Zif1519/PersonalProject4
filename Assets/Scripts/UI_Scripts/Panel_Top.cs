using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel_Top : MonoBehaviour
{
    [SerializeField] private UI_Manager uiManager;
    [SerializeField] private TextMeshProUGUI _gold;
    [SerializeField] private TextMeshProUGUI _gem;

    void Start()
    {
        gameObject.SetActive(false);
        uiManager.OnCharacterDataChanged -= OnCharacterDataChanged;
        uiManager.OnCharacterDataChanged += OnCharacterDataChanged;
    }
    private void OnDestroy()
    {
        if (uiManager != null)
        {
            uiManager.OnCharacterDataChanged -= OnCharacterDataChanged;
        }
    }

    public void OnCharacterDataChanged(CharacterData newData)
    {
        _gold.text = newData._gold.ToString() + " Gold";
        _gem.text = newData._gem.ToString() + " Gem";
    }
}
