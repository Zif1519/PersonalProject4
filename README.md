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

<<<<<<< Updated upstream
마지막에 있는 SetMainCharacter 함수의 경우에는 캐릭터 클래스가 자신이 메인캐릭터라는 것을 UI_Manager에게 알리는 함수이다.
함수가 호출되면 UI_Manager가 그때 메인 캐릭터의 Data가 변할때 호출되는 이벤트들에 구독하는 방식이다.




### 2. 인벤토리의 구조를 설계하는 부분에서의 막막함

### 3. Null 참조 에러가 마구 쏟아짐
=======

#### 1-1 생각보다 만족한 함수

마지막에 있는 SetMainCharacter 함수의 경우에는 캐릭터 클래스가 자신이 메인캐릭터라는 것을 UI_Manager에게 알리는 함수이다.
함수가 호출되면 UI_Manager가 그때 메인 캐릭터의 Data가 변할때 호출되는 이벤트들에 구독하는 방식이다.
힘들었던 점 3번이랑 연결되는 부분이다.

 Character ( 데이터가 변하는놈 )             ->            UI_Manager 옵저버 역할             <-         각종 UI_Panel          

시간 순서로 보자면
1. Character가 UI_Manager에게 자신의 존재를 알림 ( SetMainCharacter함수 호출하여 자신을 매개변수로 전달해줌)
2. UI_Manager가 Character의 존재를 파악하고 각종 데이터 변화에 대하여 옵저빙을 시작함
3. 각종 UI_Panel 들은 Start에서 자신이 필요한 정보들이 변하면 알려 달라고 UI_Manager의 이벤트들에 구독을함


여기서 중요한게 Character가 Awake나 Start 부분에서 UI_Manager의 함수들을 직접 자신의 이벤드들에 연결시키는 방식으로 하면 
Null Reference가 미친듯이 발생함... ㅋㅋ
그래서 그걸 해결하기 위해, 그냥 게임이 시작된 뒤 일정 시간이 지나고 난뒤에 Character 쪽에서 자신이 메인캐릭터라는 것을 UI_Manager에게 알리는
방식을 구현하게됨.
일정 시간이 지난다는 것은 단순하게 버튼을 클릭하게 한다거나, 1초뒤에 실행하도록 한다거나 여러 방법이 있음. 본 과제에서는 버튼을 이용

### 2. 인벤토리의 구조를 설계하는 부분에서의 막막함 + 스크립터블 오브젝트의 장점을 살리지 못하는 설계...

클래스를 어디서 부터 어디까지 쪼개야 하는지, 또한 어디서 어떤 것들을 생성하도록 만들어야 하는지 감이 안와서 시간을 많이 소비했다.
또한 스크립터블 오브젝트를 사용하려고 했는데, 막상 스크립터블 오브젝트의 사용상의 주의할 부분에 걸림..
예를 들어 아이템의 경우에는 기본아이템 정보에서 강화, 합성, 작용중, 등과 같이 개별의 아이템이 가지고 있어야 하는 정보들과,
변하지 않는 정보들이 혼재하는 탓에, 이를 모두 스크립터블 오브젝트에 담는 경우에는 아이템 수만큼 스크립터블 오브젝트를 생성해야 하는
웃픈 상황이 발생함. 이건 스크립터블 오브젝트의 활용방법이 아님.


#### 2-1 스크립터블 오브젝트는 아이템을 생성하는 단계에서 초기데이터를 입력해주는 틀의 역할로서 사용하기.

우선 스크립터블 오브젝트가 관리하는 데이터를 대폭 줄이기로 했다. Item 클래스는 따로 만들고, ItemData는 스크립터블 오브젝트로 만들었다.
ItemData는 초기 아이템 정보 ( 베이스 가격, 베이스 희귀도 (강화시에 희귀도가 바뀌도록 하려고 베이스 희귀도라고 부름) )과 같은 정보와,
Sprite, AudioClip 과 같은 정보를 담는 그릇으로 사용하기로 했다.

#### 2-2 저장기능을 대신할 그릇으로 사용하기

스크립터블 오브젝트들 만들어 놓고, 저장해야되는 영구적 변경등이 있을때만 그 데이터를 수정하도록 관리하여, 스크립터블 오브젝트를 
하나의 간편한 저장기능으로 활용하려고 CharacterData 를 만들었다.
ItemData는 매개변수로 활용하거나, 인스펙터창에서 쉽게 설정을 바꿀수 있는 데이터 관리도구이고,
이와 달리 CharacterData는 게임 종료 후에도 기록의 변화가 반영되어야 하는 데이터를 위한 그릇의 기능이 강하다.

인벤토리와 관련한 설계는 생각보다 보편적인 방식으로 구현한바 코드 설명은 생략한다.


### 3. Null 참조 에러가 마구 쏟아짐

진짜 너무 힘들었다... ㅠㅠ
>>>>>>> Stashed changes
