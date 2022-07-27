using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public TMP_Text scoreTex;
    public static GameController instance;

    private void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreTex.text = totalScore.ToString();
    }
}
