using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBGM
{

}

public enum ESE
{

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
    }


    public void PlaySE(ESE se)
    {
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
