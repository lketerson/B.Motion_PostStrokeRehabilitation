﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [SerializeField] GameObject _timerWindow;
    [SerializeField] GameObject _timerTextDisplay;
    [SerializeField] GameObject _setTimerButton;

    [SerializeField] GameObject _inputTimerField;
    [SerializeField] GameObject _inputRestTimer;
    [SerializeField] GameObject _inputSesionQtd;
    

    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _pointsDisplay;
    [SerializeField] GameObject _handModels;
    [SerializeField] GameObject _interactionManager;
    [SerializeField] GameObject _confirmButton;
    [SerializeField] GameObject _descansar;
    //[SerializeField] GameObject initialTimer;
    bool executeOnce = false;

    public int count;
    public int mediaQTD;


    string stringTimer = "0";

    bool _updateEnable;
    bool _isTimerBoxActive;

    ScoreScript score;
    CubeGame cubeGame;

 
    [HideInInspector] public int _sesionsQtd;
    [HideInInspector] public float _timer;
    [HideInInspector] public float _restTime;
    [HideInInspector] public bool reseted;

    GameObject graph;
    int _sesionsCount;
    float _startTime;
 
    

    private void Awake()
    {
        graph = GameObject.FindGameObjectWithTag("Graph");
        cubeGame = FindObjectOfType<CubeGame>();
        score = FindObjectOfType<ScoreScript>();
    }
    // Start is called before the first frame update
    void Start()
    {

        _confirmButton.active = true;
        _handModels.SetActive(false);
        _isTimerBoxActive = true;
        _updateEnable = false;
        enabled = _updateEnable;
        _gameOverMenu.SetActive(false);
        graph.SetActive(false);
        _descansar.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        _timer -= Time.deltaTime;
        _timerTextDisplay.GetComponent<Text>().text = _timer.ToString("0");
        DisplayGameOverMenu();

    }


    public void EnableTimerBox() //Activates the UI to set the time 
    {
        _isTimerBoxActive = !_isTimerBoxActive;
        _timerWindow.SetActive(_isTimerBoxActive);
        _updateEnable = !_updateEnable;
        enabled = _updateEnable;
        _handModels.SetActive(!_isTimerBoxActive);
        _interactionManager.SetActive(!_isTimerBoxActive);
    }   

    public void SetTimer()  //Confirms the play time (UI > TimerWindowMenu > SetTimer ) and shows the time in the screen
    {
        
        _restTime = float.Parse(_inputRestTimer.GetComponent<Text>().text); //Input field Rest Time to variable
        _sesionsQtd = int.Parse(_inputSesionQtd.GetComponent<Text>().text);//Input field sesions qty to variable
        stringTimer = _inputTimerField.GetComponent<Text>().text;
        _timer = float.Parse(stringTimer);
       
        _timerTextDisplay.GetComponent<Text>().text = _timer.ToString();

        if (_restTime >0  && _sesionsQtd > 0 && _timer >0 && UnityToForm.enviarForm.EnviarInformação())
        {
            Debug.Log("nada nulo");
            InitialTimer.initialTimer.time = 5f; //Reseta o contador do script initialtimer
            InitialTimer.initialTimer.initialTimerDisplay.active = true;
            _confirmButton.SetActive(false);
            score.SetScoreArray();
            _sesionsCount = _sesionsQtd;
            _startTime = _timer; //Stores the starting play time 
            Invoke("EnableTimerBox",5); //usar tempo em função do initialtimer.intialtimer.time (tempo para iniciar a partida) 
            
        }
    }

    public void CancelButton() //Close button of the time menu (UI > TimerWindowMenu > Image > Close)
    {
        _timerWindow.SetActive(false);
        StopGame();
        enabled = false;
    }

    void DisplayGameOverMenu() //Displays the game over menu if _timer <= 0 && _sesionsQtd <= 0
    {
        if (_timer <= 0 && _sesionsCount == 0)
        {
            if(executeOnce == false)
            {

                Debug.Log("SaveData");
                if (PlayerPrefs.HasKey("mediaQTD"))
                {
                    count = PlayerPrefs.GetInt("mediaQTD");
                    PlayerPrefs.SetInt("mediaQTD", count + 1);
                }
                else
                {
                    PlayerPrefs.SetInt("mediaQTD", 0);
                }
                
                score.SaveData();
                score.LoadData();
                score.SaveList();
                score.LoadList();
                LineGraphManager.lineGraph.InitializeGraphBnb();
                Debug.Log(count);

                PostInfo();
                executeOnce = true;
            }
            
            
            StopGame();            
        }
        else if(_timer <= 0 && _sesionsCount > 0)
        {
           
            NextSesion();
        }
    }

   
    private void PostInfo()
    {
        StartCoroutine(UnityToForm.enviarForm.PostBnb(UnityToForm.enviarForm.Cpf));
    }

    public void NextSesion() //When timer == 0 it disables the hands and start counting a resttimer
    {
        
        //Debug.Log(_sesionsCount);
        if (_timer <= 0)
        {
            
            _descansar.SetActive(true);
            //Debug.Log("Passou");
            score.scoresArray[_sesionsCount - 1] = score.nowPoints;
            reseted = true;
            _handModels.SetActive(false);
            _interactionManager.SetActive(false);
            
            if (_timer <= -_restTime)
            {
                _descansar.SetActive(false);
                reseted = false;
                _handModels.SetActive(true);
                _interactionManager.SetActive(true);
                _sesionsCount--;
                score.nowPoints = 0;
                _timer = _startTime;
                _gameOverMenu.SetActive(false);
                score.points = 0;

                if(_sesionsCount == 0)
                {
                    //Array to google forms
                    
                    StopGame();
                }
            }
        }        
     }


    void StopGame() //Activates the game over menu
    {
        InitialTimer.initialTimer.initialTimerDisplay.active = true;
        _pointsDisplay.SetActive(false);
        _setTimerButton.SetActive(false);
        _gameOverMenu.SetActive(true);
        _handModels.SetActive(false);
        _interactionManager.SetActive(false);
        _timer = 0;
        graph.SetActive(true);
        _confirmButton.active = true;

    }
}
