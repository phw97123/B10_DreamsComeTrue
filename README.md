
![Alt text](Untitled-1.png)
## 목차

| [게임 소개](#게임-소개) |
| :---: |
| [구현 기능](#구현-기능) |


## 게임 소개

[목차로 돌아가기](#목차)

깊은밤 버그를 해결중인 한 플레이어가 있엇습니다 이 플레이어는 해결하지 않은 버그가 많지만 너무나 졸린 나머지 버그를 해결하지못하고 잠에 빠져들게되는데...
그때 나타난 꿈속 해결사들!!!
그들은 버그를 잘 해결하고 플레이어의 고민을 덜어줄수 있을것인가!!!


![슬라이드1](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/d341c352-7932-4c41-a42e-674142345ebd)
![슬라이드2](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/e2b8cf9f-bd16-4211-b0d3-e91203231dc3)
![슬라이드3](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/b0d221fc-8f1f-4fd0-ad27-9dc20ae163cf)
![슬라이드4](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/0192d690-595a-4f0d-9244-a117f405da33)
![슬라이드5](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/4f1e1235-9946-45a2-93dc-315e9f066b5c)
![슬라이드6](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/39f3351f-ae59-4b9f-ba22-ced45bb64f89)
![슬라이드7](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/cef26702-615a-4cf1-b0f9-dd113d75c4e5)
![슬라이드8](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/50c0f68f-8202-41ba-8fe6-61ea8437704e)
![슬라이드9](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/6523205a-4a60-419c-9bf4-71c4a5712c98)
![슬라이드10](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/02e87292-871e-4fbb-be5f-dd5c10c33e55)
![슬라이드11](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/80c2a764-2f34-46bc-a3cb-d1ab534908ff)
![슬라이드12](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/2eec5142-99e9-4161-ae42-a3c6ae113802)
![슬라이드13](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/af1ad8ec-3e6a-4251-961c-7f2d1314fa13)
![슬라이드14](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/88d010ec-6b9a-40d7-847d-e16c8cb66aea)
![슬라이드15](https://github.com/phw97123/B10_DreamsComeTrue/assets/132995834/c2bd1389-ed1d-4561-8046-02eadc79c62a)








***



## 구현 기능

[목차로 돌아가기](#목차)

| Class | 기능 |
| :---: | :---: |
| UIStrartHandler | [게임시작 버튼 효과](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/UIStartHandler.cs#L68-L81) |
| StartScene | [캐릭터 선택](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/StartSceneManager.cs#L67-L119) |
| PlayerInputController | [플레이어 이동](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/PlayerMove/PlayerInputController.cs#L9-L30) |
| PlayerMoveMent | [플레이어 점프](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/PlayerMove/PlayerMoveMent.cs#L41-L49) |
| PlayerController | [플레이어 피격 효과](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/PlayerMove/PlayerController.cs#L132-L143) |
| GameManger | [게임 로직 및 난이도 조절](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/GameManager.cs#L135-L157) |
| SpawnPrefabs | [풀링오브젝트 & 섞기 & 아이템 스폰](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/ObjectsFall/SpawnPrefabs.cs#L62-L80) |
| PlayerKillObjectMove | [게임오버오브젝트 이동](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/ObjectsFall/PlayerKillObjectMove.cs#L21-L59) |
| PlayerController | [오브젝트 충돌](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/PlayerMove/PlayerController.cs#L86-L130) |
| PlayerController | [아이템 실행](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/PlayerMove/PlayerController.cs#L151-L300) |
| AudioManager | [배경음악](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/AudioManager.cs#L90-L100) |
| AudioManager | [효과음](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/AudioManager.cs#L102C25-L122) |
| TextTyping | [텍스트 한글자씩 출력](https://github.com/phw97123/B10_DreamsComeTrue/blob/bf7207c8b19e0b0063812ae7663a9d35052f8c89/Assets/Scripts/TextTyping.cs#L25-L46) |


