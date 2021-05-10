using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    [HideInInspector]
    public int points;
    TimerScript timerScript;
    public int[] scoresArray;
    public int nowPoints;
    Text score;
    private AssetBundle scenePath;


    //=============================================

    public List<float> mediaList = new List<float>();
    public int savedMediaCount;

    public void SaveList()
    {
        PlayerPrefs.SetFloat("Media_" + PlayerPrefs.GetInt("mediaQTD"), PlayerPrefs.GetFloat("media"));
        Debug.Log("ADD");
        //for (int i = 0; i < PlayerPrefs.GetInt("mediaQTD"); i++)
        //{
        //    PlayerPrefs.SetFloat("Media" + i, mediaList[i]);
        //    Debug.Log("Media" + i +": "+ mediaList[i]) ;
        //}
        //PlayerPrefs.SetInt("saveMediaCounter",mediaList.Count);
        //Debug.Log("MediaCount" + savedMediaCount);


    }

    public void LoadList()
    {
        mediaList.Clear();
        savedMediaCount = PlayerPrefs.GetInt("Count");
        for (int i = 0; i < PlayerPrefs.GetInt("mediaQTD")+1; i++)
        {
            float media = PlayerPrefs.GetFloat("Media_" + i);
            mediaList.Add(media);
            Debug.Log("Media_" + i + ": " + mediaList[i]);
        }
    }
    //=============================================

    private void Awake()
    {
        timerScript = FindObjectOfType<TimerScript>();
        score = GetComponent<Text>();
        
    }
    public void Start()
    {
        
        
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
        for (int x = 0; x < scoresArray.Length; x++)
        {
            soma += scoresArray[x];
        }
        soma = soma / scoresArray.Length;
        PlayerPrefs.SetFloat("media", soma);
       

        //SceneManager.LoadScene(1);
    }

    public void LoadData()
    {
        float media;
        scoresArray = PlayerPrefsX.GetIntArray("arrayScore");
        media = PlayerPrefs.GetFloat("media");
       
        //Debug.Log("L O A D E D");
        //Debug.Log("Media: "+ media);

    }


}
