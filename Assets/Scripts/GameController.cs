using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public TMP_Text scoreTex;
    public GameObject gameOver;
    public static GameController instance;

    private void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreTex.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        Debug.Log("die!!!!!!!!!!");
        gameOver.SetActive(true);
    }

    public void RestartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
