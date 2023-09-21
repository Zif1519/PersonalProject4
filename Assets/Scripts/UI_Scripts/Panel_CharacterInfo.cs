using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_CharacterInfo : MonoBehaviour
{
    [SerializeField] private UI_Manager uiManager;
    [SerializeField] private TextMeshProUGUI _text_CharacterName;
    [SerializeField] private TextMeshProUGUI _text_Level;
    [SerializeField] private TextMeshProUGUI _text_Exp;
    [SerializeField] private Slider _slider;

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
        _text_CharacterName.text = "ID : " + newData._characterName.ToString();
        _text_Level.text = "Level : " + newData._level.ToString();
        _text_Exp.text = "EXP  :   " + newData._exp.ToString() + " / " + (newData._level * 100).ToString();
        _slider.value = (float)newData._exp / newData._level * 0.01f;
    }
}