using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject _characterPrefab;
    public CharacterData[] _characterDatas;

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
    }

    public void OnChangeButton()
    {
        _currentCharacter.SetCharacterData(_characterDatas[1]);
    }
}
