using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUnit : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private Text rankingText;
    [SerializeField] private Text nameText;
    [SerializeField] private Text scoreText;

    public void InitData(string ranking, string name, int score)
    {
        rankingText.text = ranking.ToString();
        nameText.text = name;
        scoreText.text = score.ToString();
    }
}
