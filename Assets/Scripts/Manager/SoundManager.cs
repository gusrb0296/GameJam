using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : DontDestroy<SoundManager>
{

    public enum AUDIO_TYPE
    {
        BGM, //배경음
        SFX, //효과음
        MAX,
    }

    public enum BGM_CLIP
    {
        BGM_01,
    }

    public enum SFX_CLIP
    {
        Coin,
        Gem,
        Invincible,
        Item,
        Die,
    }
    [SerializeField]
    AudioClip[] m_bgmClip;
    [SerializeField]
    AudioClip[] m_sfxClip;
    AudioSource[] m_audio = new AudioSource[(int)AUDIO_TYPE.MAX];

    public void PlayBGM(BGM_CLIP bgm)
    {
        m_audio[(int)AUDIO_TYPE.BGM].clip = m_bgmClip[(int)bgm];
        m_audio[(int)AUDIO_TYPE.BGM].Play();
    }

    public void PlaySFX(SFX_CLIP sfx)
    {
        m_audio[(int)AUDIO_TYPE.SFX].clip = m_sfxClip[(int)sfx];
        m_audio[(int)AUDIO_TYPE.SFX].PlayOneShot(m_sfxClip[(int)sfx]); //오디오 소스는 1개인데 거기서 사운드가 바뀌면 소리가 끊겨서 PlayOneShot을 통해 소리가안끊기게함
    }

    public void SetVolume(float level)
    {
        for (int i = 0; i < m_audio.Length; i++)
        {
            m_audio[i].volume = level;
        }
    }

    public void SetVolumeBGM(float level)
    {
        m_audio[(int)AUDIO_TYPE.BGM].volume = level;
    }
    public void SetVolumeSFX(float level)
    {
        m_audio[(int)AUDIO_TYPE.SFX].volume = level;
    }
    public void SetMuteBGM()
    {
        m_audio[(int)AUDIO_TYPE.BGM].volume = 0;
    }
    public void SetMuteSFX()
    {
        m_audio[(int)AUDIO_TYPE.SFX].volume = 0;
    }

    public void StopBGM()
    {
        m_audio[(int)AUDIO_TYPE.BGM].Stop();
    }
    public void StopSFX()
    {
        m_audio[(int)AUDIO_TYPE.SFX].Stop();
    }

    public void PauseBGM()
    {
        m_audio[(int)AUDIO_TYPE.BGM].Pause();
    }

    public void ResumeBGM()
    {
        m_audio[(int)AUDIO_TYPE.BGM].Play();
    }

    public void PauseSFX()
    {
        m_audio[(int)AUDIO_TYPE.SFX].Pause();
    }

    // Use this for initialization
    protected override void OnStart()
    {
        base.OnStart();
        m_audio[(int)AUDIO_TYPE.BGM] = gameObject.AddComponent<AudioSource>();
        m_audio[(int)AUDIO_TYPE.BGM].playOnAwake = false;
        m_audio[(int)AUDIO_TYPE.BGM].loop = true;

        m_audio[(int)AUDIO_TYPE.SFX] = gameObject.AddComponent<AudioSource>();
        m_audio[(int)AUDIO_TYPE.SFX].playOnAwake = false;
        m_audio[(int)AUDIO_TYPE.SFX].loop = false;
    }
}
