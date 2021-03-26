using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreScript : MonoBehaviour
{
    [HideInInspector]
    public int points;
    TimerScript timerScript;
    public int[] scoresArray;
    public int nowPoints;
    Text score;


    public void Start()
    {
        timerScript = FindObjectOfType<TimerScript>();
        score = GetComponent<Text>();
        nowPoints = 0;
        
    }

    private void Update()
    {
        score.text = "PONTOS: " + points.ToString();
        //if (timerScript.reseted)
        //{
        //    nowPoints = 0;
        //}

    }

    public void scoreCount()
    {
        points++;
        nowPoints = points;
    }

    public void SetScoreArray()
    {
        scoresArray = new int[timerScript._sesionsQtd];
    }

    public void SaveData()
    {
        float soma=0;
        Array.Reverse(scoresArray, 0, scoresArray.Length);
        PlayerPrefsX.SetIntArray("arrayScore", scoresArray);
        Debug.Log("S A V E D");
        for (int x = 0; x < scoresArray.Length; x++)
        {
            soma += scoresArray[x];
        }
        soma = soma / scoresArray.Length;
        PlayerPrefs.SetFloat("media", soma);
    }

    public void LoadData()
    {
        float media;
        scoresArray = PlayerPrefsX.GetIntArray("arrayScore");
        media = PlayerPrefs.GetInt("media");
        Debug.Log("L O A D E D");
        Debug.Log("Media: "+ media);
        
    }


}
