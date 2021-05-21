using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReactionTimeScoreController : MonoBehaviour
{

    int sesionCount;
    int miniSesionCount;
    float mediaRt;
    float miniMediaRt;
    float[] pontuacaoArray;
    float[] miniPontuacaoArray;
    float pontuacao;

    [SerializeField]
    ReactionTimeController rtController;
    
    /*====================GETTERS AND SETTERS====================*/
    public int SesionCount { get => sesionCount; set => sesionCount = value; }
    public float MediaRt { get => mediaRt; set => mediaRt = value; }
    public float[] PontuacaoArray { get => pontuacaoArray; set => pontuacaoArray = value; }
    public float Pontuacao { get => pontuacao; set => pontuacao = value; }
    public float[] MiniPontuacaoArray { get => miniPontuacaoArray; set => miniPontuacaoArray = value; }
    public float MiniMediaRt { get => miniMediaRt; set => miniMediaRt = value; }
    public int MiniSesionCount { get => miniSesionCount; set => miniSesionCount = value; }

    /*===========================================================*/

    // Start is called before the first frame update
    void Start()
    {
        //PontuacaoArray = new float [rtController.SesionQtd];
        MiniPontuacaoArray = new float[5];
        MiniSesionCount = 4;
        SesionCount = 0;
        Pontuacao = 0;
        MediaRt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < pontuacaoArray.Length; i++)
            {
                Debug.Log(PontuacaoArray[i]);
            }
        }

        
        
    }

    private void AddScore(int index)
    {
        PontuacaoArray[index] = MiniMediaRt;
    }

    public void MiniMediaAddScore(int index, float pontuacao)
    {
        
        if (index >= 0)
        {
            MiniPontuacaoArray[index] = pontuacao;
            Debug.Log("Res" + index + ": " + MiniPontuacaoArray[index]);
            
        }
        MiniSesionCount = MiniSesionCount - 1;
        if (index <=0)
        {            
            MiniMediaRt = miniPontuacaoArray.Average();

            miniSesionCount = 4;
            AddScore(SesionCount);
            sesionCount++;
            //MiniPontuacaoArray[miniSesionCount] = pontuacao;
            for (int i = 0; i < MiniPontuacaoArray.Length; i++)
            {
                Debug.Log("MiniPos" + i + ": " + MiniPontuacaoArray[i]);
            }

            if (SesionCount >= rtController.SesionQtd)
            {
                Debug.Log("Array final___________");
                for (int i = 0; i < PontuacaoArray.Length; i++)
                {
                    Debug.Log(PontuacaoArray[i]);
                }
                rtController.GameOver();
            }
        }

        
        
    }
}
