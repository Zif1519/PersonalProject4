using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Status : MonoBehaviour
{
    [SerializeField] private UI_Manager uiManager;
    [SerializeField] private TextMeshProUGUI _text_Attack;
    [SerializeField] private TextMeshProUGUI _text_Defence;
    [SerializeField] private TextMeshProUGUI _text_Critical;
    [SerializeField] private TextMeshProUGUI _text_Health;
    [SerializeField] private TextMeshProUGUI _text_Dodge;
    [SerializeField] private TextMeshProUGUI _text_Speed;
    [SerializeField] private TextMeshProUGUI _characterDescription;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        uiManager.OnStatusChanged -= OnStatusChanged;
        uiManager.OnStatusChanged += OnStatusChanged;
        uiManager.OnViewStateChanged += OnViewStateChanged;
        uiManager.OnCharacterDataChanged += OnCharacterChanged;
    }

    private void OnDestroy()
    {
        if (uiManager != null)
        {
            uiManager.OnStatusChanged -= OnStatusChanged;
            uiManager.OnCharacterDataChanged -= OnCharacterChanged;
        }
    }

    public void OnStatusChanged(StatusData newStatus)
    {
        _text_Attack.text = newStatus._Attack.ToString();
        _text_Defence.text = newStatus._Defence.ToString();
        _text_Critical.text = newStatus._Critical.ToString();
        _text_Health.text = newStatus._Health.ToString();
        _text_Dodge.text = newStatus._Dodge.ToString();
        _text_Speed.text = newStatus._Speed.ToString();
    }

    public void OnViewStateChanged(VIEWSTATE newViewState)
    {
        if (newViewState == VIEWSTATE.STATUS)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnCharacterChanged(CharacterData newCharacterData)
    {
        _characterDescription.text = "  Ä³¸¯ÅÍ Æ¯Â¡  : \n" + newCharacterData._characterDescription;
    }
}
