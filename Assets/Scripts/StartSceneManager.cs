using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

//캐릭터 이름
public enum CharacterName
{
    PHW,JBJ,KEJ,JJH
}

public class StartSceneManager : MonoBehaviour
{
    //StartSceneManager 클래스의 인스턴스를 다른 스크립트에서 참조하기 위한 정적 변수
    public static StartSceneManager Instance;

    private  UIStartHandler uiStartHandler; // UIStartHandler 클래스의 인스턴스를 저장하는 변수

    private int spriteCount = 0;

    public CharacterName characterName = CharacterName.PHW; 

    public Sprite[] characterSprite;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject selectCharacter;

    //상수
    public const string UIHANDLER_NAME = "uiStartHandler";
    public const string PLAYERPREFS_CHARACTERNUMBER = "CharacterNumber";
    public const string SAMPLESCENE = "SampleScene"; 

    private void Awake()
    {
        if (Instance == null)  //1. 인스턴스가 아직 생성되지 않았을 경우 
            Instance = this;
        else if (Instance != this)  //2.이미 다른 인스턴스가 존재할 경우 
        {
            Destroy(gameObject); // 메서드 파괴후 종료 
            return; //더이상의 코드를 막기 위해 
        }
        else  // 3.Instance 변수가 이미 현재 인스턴스를 참조하고 있을 경우 다음씬으로 갈 때 파괴하지 않음 
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // UIManager의 Dictionary에 있는 UIStartHandler 스크립트를 가져와 uiStartHandler에 할당
        uiStartHandler = UIManager.Instance.GetUIScript<UIStartHandler>(UIHANDLER_NAME);
        spriteRenderer = selectCharacter.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = characterSprite[(int)characterName];
    }

    public void StartGame()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);
        PlayerPrefs.SetInt(PLAYERPREFS_CHARACTERNUMBER, (int)characterName);
        UIManager.Instance.RemoveUIScript(UIHANDLER_NAME);
        AudioManager.Instance.PlayIntro(false);
        SceneManager.LoadScene(SAMPLESCENE); 
    }

    public void ShowCharacter(bool moveLeft)
    {
        //캐릭터 스프라이트가 배열에 없다면 아무 작업도 하지 않고 종료 
        if (characterSprite.Length == 0)
            return;

        //왼쪽 버튼
        if (moveLeft)
        {
            //이전 캐릭터의 인덱스를 구하고 음수가 되지 않기 위해 배열의 길이를 더하고 배열의 길이를 초과하지 않게 처리 
            spriteCount = (spriteCount - 1 + characterSprite.Length) % characterSprite.Length;
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);

        }
        else //오른쪽 버튼
        {
            //배열의 길이를 나눈 나머지를 사용함으로써 배열의 길이르 초과하지 않게 처리 
            spriteCount = (spriteCount + 1) % characterSprite.Length;
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);

        }

        characterName = (CharacterName)spriteCount;
        Vector3 currentPosition = selectCharacter.transform.position;

        //Sprite 크기가 달라서 위치 조정 및 캐릭터 설명

        switch (characterName)
        {
            case CharacterName.PHW :
                currentPosition.y = -1.5f;
                uiStartHandler.SetCharacterInfo("PHW", "마비시간 1, 속도 1", "PlayStation5를 좋아합니다.");
                break;

            case CharacterName.JBJ:
                currentPosition.y = -1.6f;
                uiStartHandler.SetCharacterInfo("JBJ", "크기 Down, 마비시간 1.25", "FIFA를 좋아합니다.");
                break;

            case CharacterName.KEJ:
                currentPosition.y = -2f;
                uiStartHandler.SetCharacterInfo("KEJ", "마비시간 0.75", "와인을 좋아합니다.");
                break;

            case CharacterName.JJH:
                currentPosition.y = -1.9f;
                uiStartHandler.SetCharacterInfo("JJH", "속도 1.25", "자는 것을 좋아합니다");
                break; 
        }
        
        selectCharacter.transform.position = currentPosition;
        spriteRenderer.sprite = characterSprite[(int)characterName];
    }
}
