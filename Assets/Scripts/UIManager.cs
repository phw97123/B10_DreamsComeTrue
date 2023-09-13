using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //UIManager 클래스의 인스턴스를 다른 스크립트에서 참조하기 위한 정적 변수
    public static UIManager Instance;

    // UI 스크립트를 저장하는 Dictionary
    private Dictionary<string, MonoBehaviour> uiScripts = new Dictionary<string, MonoBehaviour>();


    // UI 스크립트를 Dictionary에 추가하는 메서드
    public void AddUIScript(string scriptName, MonoBehaviour uiScript)
    {
        if (!uiScripts.ContainsKey(scriptName))
        {
            uiScripts.Add(scriptName, uiScript);
        }
        else
        {
            Debug.LogWarning("이미 같은 이름으로 UI 스크립트가 추가되었습니다: " + scriptName);
        }
    }

    //등록된 UI스크립트를 Dictionary찾아서 반환하는 메서드
    //Where : 제네릭 형식 매개변수에 대한 제약을 설정
    // T는 MonoBehaviour 형식 또는 그 하위 형식이어야 함 
    public T GetUIScript<T>(string scriptName) where T : MonoBehaviour
    {
        if (uiScripts.ContainsKey(scriptName))
            return uiScripts[scriptName] as T;
        else
        {
            Debug.LogWarning("해당 이름의 UI 스크립트를 찾을 수 없습니다: " + scriptName);
            return null;
        }
    }

    public void RemoveUIScript(string scriptName)
    {
        if (uiScripts.ContainsKey(scriptName))
        {
            uiScripts.Remove(scriptName);
        }
        else
        {
            Debug.LogWarning("해당 이름의 UI 스크립트를 찾을 수 없어 제거할 수 없습니다: " + scriptName);
        }
    }

    void Awake()
    {
        if (Instance == null) //UIManager에 인스턴스가 없으면 현재 인스턴스
            Instance = this;
        else if (Instance != this) //이미 인스턴스가 존재하면
        {
            Destroy(gameObject);// 현재 인스턴스를 파괴하여 중복 생성 방지
            return;
        }

        DontDestroyOnLoad(gameObject); // 씬 전환 시에도 이 게임 오브젝트를 파괴하지 않도록 설정
    }
}
