using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBGM
{
    Background
}

public enum ESE
{
    button,
    jump,  // flap?,  jump2
    item,
    reward,
    failed
}

public class SoundManager
{
    private Dictionary<EBGM, AudioClip> _bgmDic;
    private Dictionary<ESE, AudioClip> _seDic;

    private AudioSource _bgmAudio = null;
    private AudioSource _seAudio = null;

    public float bgmVolume = 0.5f;
    public float seVolume = 0.5f;

    public void Init()
    {
        if(_bgmAudio == null)
        {
            GameObject go = new GameObject("BGMSound");
            go.transform.parent = GameManager.Instance.transform;
            _bgmAudio = go.AddComponent<AudioSource>();
            _bgmAudio.loop = true;

            GameObject go1 = new GameObject("EffectSound");
            go1.transform.parent = GameManager.Instance.transform;
            _seAudio = go1.AddComponent<AudioSource>();
            _seAudio.loop = false;
        }

        _bgmAudio.volume = bgmVolume;
        _seAudio.volume = seVolume;

        _bgmDic = new Dictionary<EBGM, AudioClip>();
        _seDic = new Dictionary<ESE, AudioClip>();

        _bgmDic[EBGM.Background] = Resources.Load<AudioClip>("Audio/background");

        _seDic[ESE.button] = Resources.Load<AudioClip>("Audio/button");
        _seDic[ESE.jump] = Resources.Load<AudioClip>("Audio/jump2");
        _seDic[ESE.item] = Resources.Load<AudioClip>("Audio/item");
        _seDic[ESE.reward] = Resources.Load<AudioClip>("Audio/rewarded");
        _seDic[ESE.failed] = Resources.Load<AudioClip>("Audio/failed");
    }


    public void PlaySE(ESE se)
    {
        if (!_seDic.ContainsKey(se))
        {
            Debug.Log("없는 BGM 입니다.");
            return;
        }

        _seAudio.PlayOneShot(_seDic[se]);
    }

    public void PlayBgm(EBGM bgm)
    {
        if (!_bgmDic.ContainsKey(bgm))
        {
            Debug.Log("없는 BGM 입니다.");
            return;
        }

        if (_bgmAudio.clip == _bgmDic[bgm])
        {
            Debug.Log("동일한 Clip입니다.");
            return;
        }

        _bgmAudio.Stop();
        _bgmAudio.clip = _bgmDic[bgm];
        _bgmAudio.Play();
    }
}
