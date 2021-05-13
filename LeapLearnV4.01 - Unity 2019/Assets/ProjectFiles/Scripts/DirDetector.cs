using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirDetector : MonoBehaviour
{
    [SerializeField]
    private Text gameText;

    Camera mainCamera;

    bool trueDir, active, opened, canPosition, timerCanBeStoped, timerIsUp;

    float randomInitializeTimer, startTime, reactionTime;


    public bool TrueDir { get => trueDir; set => trueDir = value; }
    public bool Active { get => active; set => active = value; }
    public bool Opened { get => opened; set => opened = value; }
    public bool CanPosition { get => canPosition; set => canPosition = value; }
    public float RandomInitializeTimer { get => randomInitializeTimer; set => randomInitializeTimer = value; }
    public bool TimerCanBeStoped { get => timerCanBeStoped; set => timerCanBeStoped = value; }
    public float StartTime { get => startTime; set => startTime = value; }
    public bool TimerIsUp { get => timerIsUp; set => timerIsUp = value; }
    public float ReactionTime { get => reactionTime; set => reactionTime = value; }




    // Start is called before the first frame update
    void Start()
    {
        ReactionTime = 0f;
        StartTime = 0f;
        mainCamera = Camera.main;
        TimerIsUp = false;
        TimerCanBeStoped = true;
        gameText.text = "Posicione para Começar";
    }

    // Update is called once per frame
    void Update()
    {
        TooEarly();
    }


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
        if (!TimerIsUp && !TrueDir && !Active)
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
                Active = false;
                StopCoroutine("StartClock");
                ReactionTime = Time.time - startTime ;
                gameText.text = "Reaction time: \n" + ReactionTime.ToString("N3") + "sec\n" + "Posicione para começar novamente";
                Debug.Log("Reaction time: \n" + ReactionTime.ToString("N3") + "sec\n" + "Posicione para começar novamente");
                TimerIsUp = false;
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
