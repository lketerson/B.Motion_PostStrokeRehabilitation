using System.Collections;
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




    string stringTimer = "0";

    bool _updateEnable;
    bool _isTimerBoxActive;

    ScoreScript score;
    CubeGame cubeGame;


    [HideInInspector] public int _sesionsQtd;
    [HideInInspector] public float _timer;
    [HideInInspector] public float _restTime;
    [HideInInspector] public bool reseted;
    int _sesionsCount;
    float _startTime;

    
    // Start is called before the first frame update
    void Start()
    {
        cubeGame = FindObjectOfType<CubeGame>();
        score = FindObjectOfType<ScoreScript>();
        _handModels.SetActive(false);
        _isTimerBoxActive = true;
        _updateEnable = false;
        enabled = _updateEnable;
        _gameOverMenu.SetActive(false);
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
        _sesionsCount = _sesionsQtd;
        stringTimer = _inputTimerField.GetComponent<Text>().text;
        _timer = float.Parse(stringTimer);
        _timerTextDisplay.GetComponent<Text>().text = _timer.ToString();
        _startTime = _timer; //Stores the starting play time 
        score.SetScoreArray(); 
        EnableTimerBox();
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
            StopGame();            
        }
        else if(_timer <= 0 && _sesionsCount > 0)
        {
           
            NextSesion();
        }
    }


    public void NextSesion() //When timer == 0 it disables the hands and start counting a resttimer
    {
        
        if (_timer <= 0)
        {
            score.scoresArray[_sesionsCount - 1 ] = score.nowPoints;
            reseted = true;
            _handModels.SetActive(false);
            _interactionManager.SetActive(false);
            
            if (_timer <= -_restTime)
            {
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
        _pointsDisplay.SetActive(false);
        _setTimerButton.SetActive(false);
        _gameOverMenu.SetActive(true);
        _handModels.SetActive(false);
        _interactionManager.SetActive(false);
        _timer = 0;

    }
}
