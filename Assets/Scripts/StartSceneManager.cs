using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

//ĳ���� �̸�
public enum CharacterName
{
    PHW,JBJ,KEJ,JJH
}

public class StartSceneManager : MonoBehaviour
{
    //StartSceneManager Ŭ������ �ν��Ͻ��� �ٸ� ��ũ��Ʈ���� �����ϱ� ���� ���� ����
    public static StartSceneManager Instance;

    private  UIStartHandler uiStartHandler; // UIStartHandler Ŭ������ �ν��Ͻ��� �����ϴ� ����

    private int spriteCount = 0;

    public CharacterName characterName = CharacterName.PHW; 

    public Sprite[] characterSprite;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject selectCharacter;

    //���
    public const string UIHANDLER_NAME = "uiStartHandler";
    public const string PLAYERPREFS_CHARACTERNUMBER = "CharacterNumber";
    public const string SAMPLESCENE = "SampleScene"; 

    private void Awake()
    {
        if (Instance == null)  //1. �ν��Ͻ��� ���� �������� �ʾ��� ��� 
            Instance = this;
        else if (Instance != this)  //2.�̹� �ٸ� �ν��Ͻ��� ������ ��� 
        {
            Destroy(gameObject); // �޼��� �ı��� ���� 
            return; //���̻��� �ڵ带 ���� ���� 
        }
        else  // 3.Instance ������ �̹� ���� �ν��Ͻ��� �����ϰ� ���� ��� ���������� �� �� �ı����� ���� 
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // UIManager�� Dictionary�� �ִ� UIStartHandler ��ũ��Ʈ�� ������ uiStartHandler�� �Ҵ�
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
        //ĳ���� ��������Ʈ�� �迭�� ���ٸ� �ƹ� �۾��� ���� �ʰ� ���� 
        if (characterSprite.Length == 0)
            return;

        //���� ��ư
        if (moveLeft)
        {
            //���� ĳ������ �ε����� ���ϰ� ������ ���� �ʱ� ���� �迭�� ���̸� ���ϰ� �迭�� ���̸� �ʰ����� �ʰ� ó�� 
            spriteCount = (spriteCount - 1 + characterSprite.Length) % characterSprite.Length;
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);

        }
        else //������ ��ư
        {
            //�迭�� ���̸� ���� �������� ��������ν� �迭�� ���̸� �ʰ����� �ʰ� ó�� 
            spriteCount = (spriteCount + 1) % characterSprite.Length;
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);

        }

        characterName = (CharacterName)spriteCount;
        Vector3 currentPosition = selectCharacter.transform.position;

        //Sprite ũ�Ⱑ �޶� ��ġ ���� �� ĳ���� ����

        switch (characterName)
        {
            case CharacterName.PHW :
                currentPosition.y = -1.5f;
                uiStartHandler.SetCharacterInfo("PHW", "����ð� 1, �ӵ� 1", "PlayStation5�� �����մϴ�.");
                break;

            case CharacterName.JBJ:
                currentPosition.y = -1.6f;
                uiStartHandler.SetCharacterInfo("JBJ", "ũ�� Down, ����ð� 1.25", "FIFA�� �����մϴ�.");
                break;

            case CharacterName.KEJ:
                currentPosition.y = -2f;
                uiStartHandler.SetCharacterInfo("KEJ", "����ð� 0.75", "������ �����մϴ�.");
                break;

            case CharacterName.JJH:
                currentPosition.y = -1.9f;
                uiStartHandler.SetCharacterInfo("JJH", "�ӵ� 1.25", "�ڴ� ���� �����մϴ�");
                break; 
        }
        
        selectCharacter.transform.position = currentPosition;
        spriteRenderer.sprite = characterSprite[(int)characterName];
    }
}
