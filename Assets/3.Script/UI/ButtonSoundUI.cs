using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundUI : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => GameManager.Instance.Sound.PlaySE(ESE.button));
    }

    
    
}
