using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject _characterPrefab;
    public CharacterData[] _characterDatas;
    public bool _isWhiteFox=false;

    public Character _currentCharacter;
    private void Start()
    {

    }

    public void OnButtonClick()
    {
        var character = Instantiate(_characterPrefab, Vector3.zero, Quaternion.identity);
        _currentCharacter = character.GetComponent<Character>();
        UI_Manager.Instance.SetMainCharacter(_currentCharacter);
        _currentCharacter.SetCharacterData(_characterDatas[0]);
        _isWhiteFox = true;
    }

    public void OnChangeButton()
    {
        if (_isWhiteFox)
        {
            _currentCharacter.SetCharacterData(_characterDatas[1]);
            _isWhiteFox = false;
        }
        else
        {
            _currentCharacter.SetCharacterData(_characterDatas[0]);
            _isWhiteFox = true;
        }
        
    }
}
