using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Instance;

    [Header("#BGM")]
    public AudioClip[] bgmClip;
    public float bgmVolume;
    public int channel;
    AudioSource[] bgmPlayer;
    int channelIndex;

    public enum Bgm { StartScene, MainScene };

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelsIndex;

    public enum Sfx { jump, button, gameover = 3, PS5, FIFA, Wine, SleepSound }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Init();
    }

    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = new AudioSource[channel];

        for (int index = 0; index < bgmPlayer.Length; index++)
        {
            bgmPlayer[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayer[index].playOnAwake = false;
            bgmPlayer[index].loop = true;
            bgmPlayer[index].volume = bgmVolume;
        }


        // 효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    public void PlayBgm(bool isPlay)
    {
        if (isPlay)
        {
            if (bgmPlayer[0])
            {
                bgmPlayer[0].Play();
            }
            else if (bgmPlayer[1])
            {
                bgmPlayer[1].Play();
            }
        }
        else
        {
            if (bgmPlayer[0])
            {
                bgmPlayer[0].Stop();
            }
            else if (bgmPlayer[1])
            {
                bgmPlayer[1].Stop();
            }
        }
    }

    public void PlayBgm(Bgm bgm)
    {
        for (int index = 0; index < bgmPlayer.Length; index++)
        {
            int loopIndex = (index + channelIndex) % bgmPlayer.Length;
            if (bgmPlayer[loopIndex].isPlaying)
            {
                continue;
            }
            channelIndex = loopIndex;
            bgmPlayer[loopIndex].clip = bgmClip[(int)bgm];
            bgmPlayer[loopIndex].Play();
            break;
        }
    }
    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopsIndex = (index + channelsIndex) % sfxPlayers.Length;
            if (sfxPlayers[loopsIndex].isPlaying)
            {
                continue;
            }

            int ranIndex = 0;
            if (sfx == Sfx.button)
            {
                ranIndex = Random.Range(0, 2);
            }
            channelsIndex = loopsIndex;
            sfxPlayers[loopsIndex].clip = sfxClips[(int)sfx + ranIndex];
            sfxPlayers[loopsIndex].Play();
            break;
        }
    }
}
