using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionTimeController : MonoBehaviour
{
    [SerializeField]
    private Text gameText;
    [SerializeField]
    private ReactionTimeScoreController scoreController;
    [SerializeField]
    private GameObject sesionQtdInput;
    [SerializeField]
    private GameObject handModels;
    [SerializeField]
    private GameObject definicoesUI;
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject menuUI;
    [SerializeField]
    private Image background;

    Camera mainCamera;

    bool trueDir, active, opened, canPosition, timerCanBeStoped, timerIsUp, gameStarted;

    float randomInitializeTimer, startTime, reactionTime;
    int sesionQtd, miniSesionQtd;


    /*====================GETTERS AND SETTERS====================*/
    public bool TrueDir { get => trueDir; set => trueDir = value; }
    public bool Active { get => active; set => active = value; }
    public bool Opened { get => opened; set => opened = value; }
    public bool CanPosition { get => canPosition; set => canPosition = value; }
    public float RandomInitializeTimer { get => randomInitializeTimer; set => randomInitializeTimer = value; }
    public bool TimerCanBeStoped { get => timerCanBeStoped; set => timerCanBeStoped = value; }
    public float StartTime { get => startTime; set => startTime = value; }
    public bool TimerIsUp { get => timerIsUp; set => timerIsUp = value; }
    public float ReactionTime { get => reactionTime; set => reactionTime = value; }
    public int SesionQtd { get => sesionQtd; set => sesionQtd = value; }
    public bool GameStarted { get => gameStarted; set => gameStarted = value; }
    public int MiniSesionQtd { get => miniSesionQtd; set => miniSesionQtd = value; }

    /*===========================================================*/




    // Start is called before the first frame update
    void Start()
    {
        menuUI.SetActive(true);
        ReactionTime = 0f;
        StartTime = 0f;
        mainCamera = Camera.main;
        TimerIsUp = false;
        TimerCanBeStoped = true;
        gameText.text = "Posicione para Começar";
        handModels.SetActive(false);
        GameStarted = false;
        gameOverUI.SetActive(false);
        definicoesUI.SetActive(true);
    }

    void Update()
    {
        TooEarly();
        if (scoreController.lineGraph.active)
        {
            scoreController.LaunchGraph();
        }
        else
        {
            Debug.Log("Esperando");
        }
       
    }

    public void StartGame()
    {
        SesionQtd =  int.Parse(sesionQtdInput.GetComponent<Text>().text);
        if (UnityToForm.enviarForm.EnviarInformação() && SesionQtd > 0) //Valida CPF
        {
            scoreController.PontuacaoArray = new float[sesionQtd];
            GameStarted = true;
            MenuPrincipalAtivo(false);
            MiniSesionQtd = scoreController.MiniPontuacaoArray.Length;
        }
        
      
    }

    public void GameOver()
    {
        GameOverAtivo(true);
    }


    public void GameOverAtivo(bool status)
    {
        menuUI.SetActive(status);
        gameOverUI.SetActive(status);
        handModels.SetActive(!status);
        gameText.enabled = !status;
        background.enabled = !status;
    }

    public void MenuPrincipalAtivo(bool status)
    {
        definicoesUI.SetActive(status);
        menuUI.SetActive(status);
        handModels.SetActive(!status);
    }
    // Update is called once per frame
   


    public void FalseDirection()
    {
        TrueDir = false;
    }
    
    public void TrueDirection()
    {    
        TrueDir = true;
        TooEarly();
    }

    public void HandClosed()
    {   
        Opened = false;
        TooEarly();
        
    }
    public void HandOpened()
    {
        Opened = true;
    }

    public void StartCount()
    {
        if (!TimerIsUp && !TrueDir && !Active && GameStarted && SesionQtd > 0)
        {
            StartCoroutine("StartClock");
            gameText.text = "Espere o verde";
            mainCamera.backgroundColor = new Color(0, 0, 1);
            TimerIsUp = true;
            TimerCanBeStoped = false;
            Active = false;
        }
    }

    public void AddScore()
    {
        if (Active)
        {
            if (TimerIsUp && TimerCanBeStoped && !Opened && TrueDir)
            {
                Debug.Log("Ses: " + SesionQtd);
                Active = false;
                StopCoroutine("StartClock");
                ReactionTime = Time.time - startTime ;
                gameText.text = "Tempo de reação: \n" + ReactionTime.ToString("N3") + "sec\n" + "Posicione para começar novamente";
                TimerIsUp = false;
                Debug.Log("MiniCount: "+scoreController.MiniSesionCount);
                
                scoreController.MiniMediaAddScore(scoreController.MiniSesionCount, ReactionTime);
                //scoreController.MiniSesionCount = scoreController.MiniSesionCount - 1;
                //if (scoreController.MiniSesionCount < 0)
                //{
                //    scoreController.MiniSesionCount = 4;
                //}


            }
        }
    }

    public void StopCount()
    {
        Debug.Log("Wrong Position");
        
    }


    private IEnumerator StartClock()
    {
        RandomInitializeTimer = Random.Range(2f, 10f);
        Debug.Log("Não Passou");
        yield return new WaitForSeconds(RandomInitializeTimer);
        Debug.Log("Passou");
        active = true;
        TimerCanBeStoped = true;
        timerIsUp = true;
        mainCamera.backgroundColor = new Color(0, 1, 0);
        StartTime = Time.time;
    }

    private void TooEarly()
    {
        if (!Active &&(TrueDir || !Opened))
        {
            if (timerIsUp && !TimerCanBeStoped)
            {
                StopCoroutine("StartClock");
                mainCamera.backgroundColor = new Color(1, 0, 0);
                ReactionTime = 0f;
                TimerIsUp = false;
                TimerCanBeStoped = true;
                gameText.text = "Muito Cedo\n" + "Posicione para começar";
                active = false;
            }
            else
            {
                Debug.Log("Awaiting");
            }
        }
        
    }
    
}
