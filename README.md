# PersonalProject4

시간이 모자란 관계로 UI 에셋들을 구하지 못해서 사각이미지를 많이 활용한 점 양해 바랍니다.

![PlayScreenshot](https://github.com/Zif1519/PersonalProject4/assets/141081153/28762aed-9e36-4664-9c65-fb642a0d066a)


# 필수 과제 해결
### 1. 메인화면구성

레벨 / 골드 / Status 버튼 / Inventory 버튼 구성하기

### 2. Status 보기

Status 버튼 / Inventory 버튼 사라지기
우측에 캐릭터 정보 표현하기
뒤로가기 버튼으로 1번 화면으로 이동하기

### 3. 인벤토리 보기 ( 미완성 )
아이템 클릭시 장착관리
현재 팝업창과 연결을 하지 못한채, 장비아이템의 경우에 클릭시 착용 되도록만 설정된 상태.


# 과제 해결시 어려웠던 점
### 1. UI_Manager와 여러 UI 요소들과의 관계 설정 및 코드 작성
UI_Manager의 역할을 어떻게 설정하여야 하는지 고민이 많았다.
처음에는 모든 UI 의 동작을 UI_Manager가 수행하도록 하려고 했으나, 단일책임의 원칙에 위배되는 코드를 피하기 위해
여러 UI 요소들의 스크립트를 나눠 관리하기로 했다.

여러 시행착오들이 있었지만, 그 과정을 다 적기엔 너무 길어지니 결과적으로 구현하게 된 구조를 소개한다.

UI_Manager가 싱글턴으로 존재한다.
UI_Manager는 CharacterData, StatusData, InventoryData, VIEWSTATE 이렇게 4가지 정보들의 변화에 반응하도록 설정했다.
4가지를 모두 Call 메서드와, Event를 추가하여, 4가지 데이터의 변화에 따라서 그 UI 정보를 갱신해야 하는 UI들은 
그 UI들의 Start에서 각각의 이벤트에 자신의 함수들을 구독하는 방식으로 구현했다.

  
            using System;
            using System.Collections;
            using System.Collections.Generic;
            using UnityEngine;
            
            public enum VIEWSTATE { MAIN = 0, STATUS, INVENTORY }
            public class UI_Manager : MonoBehaviour
            {
                public static UI_Manager Instance;
            
                public VIEWSTATE _CurrentViewState = VIEWSTATE.MAIN;
                public event Action<StatusData> OnStatusChanged;
                public event Action<InventoryData> OnInventoryDataChanged;
                public event Action<VIEWSTATE> OnViewStateChanged;
                public event Action<CharacterData> OnCharacterDataChanged;
                
                {생략}
            
                public void CallEventStatusChanged(StatusData newStatusData)
                {
                    OnStatusChanged?.Invoke(newStatusData);
                }
                public void CallEventInventoryChanged(InventoryData newInventoryData)
                {
                    OnInventoryDataChanged?.Invoke(newInventoryData);
                }
                public void CallEventViewStateChanged(VIEWSTATE newViewState)
                {
                    OnViewStateChanged?.Invoke(newViewState);
                }
                public void CallEventCharacterDataChanged(CharacterData newCharacterData)
                {
                    OnCharacterDataChanged?.Invoke(newCharacterData);
                }
            
            {생략}
            
                public void SetMainCharacter(Character newCharacter)
                {
                    newCharacter.OnCharacterDataChanged += CallEventCharacterDataChanged;
                    newCharacter.OnInventoryDataChanged += CallEventInventoryChanged;
                    newCharacter.OnStatusDataChanged += CallEventStatusChanged;
            
                    CallEventViewStateChanged(VIEWSTATE.MAIN);
                }

                {생략}
            }

생각보다 어려웠던 것이, UI_Manager가 Instance에 자기 자신을 넣는 시기와, 다른 UI 패널들이 UI_Manager에 자신의 함수들을 구독시키는 
시기가 겹쳐서 Null Reference 에러가 발생하는 부분이었다. UI_Panel들이 직접연결 없이 static으로 선언된 Instance로 접근해서 연결을 시키려
했는데, 이 방식으로는 도저히 조절이 안되서 결국에는 SerializeField로 선언하여 인스펙터 창에서 매니저를 연결해서 사용했다.
인스펙터 창에 연결시켜서 사용하는게 좀더 빠른것 같았다. Static 으로 접근하는 방식에선 Awake 나 OnEnable에서 Null Reference에러가 발생해서..

마지막에 있는 SetMainCharacter 함수의 경우에는 캐릭터 클래스가 자신이 메인캐릭터라는 것을 UI_Manager에게 알리는 함수이다.
함수가 호출되면 UI_Manager가 그때 메인 캐릭터의 Data가 변할때 호출되는 이벤트들에 구독하는 방식이다.




### 2. 인벤토리의 구조를 설계하는 부분에서의 막막함

### 3. Null 참조 에러가 마구 쏟아짐
