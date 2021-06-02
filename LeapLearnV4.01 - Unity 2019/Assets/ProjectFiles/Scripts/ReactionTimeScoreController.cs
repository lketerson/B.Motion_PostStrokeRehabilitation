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
    float avg;
    int generalCount;
    bool executeOnce = false;

    List<float> mediaList = new List<float>();

    public GameObject lineGraph;

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
    public float Avg { get => avg; set => avg = value; }
    public int GeneralCount { get => generalCount; set => generalCount = value; }

    /*===========================================================*/

    // Start is called before the first frame update
    void Start()
    {
        lineGraph.SetActive(false);
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

    public void LaunchGraph()
    {
        if (!executeOnce)
        {
            LineGraphManager.lineGraph.InitializeGraphBnb();
            executeOnce = true;
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
                Avg = pontuacaoArray.Average();
        
                if (PlayerPrefs.HasKey("MediaQTD_RT"))
                {
                    GeneralCount = PlayerPrefs.GetInt("MediaQTD_RT");
                    PlayerPrefs.SetInt("MediaQTD_RT", GeneralCount +1);
                }
                else
                {
                    PlayerPrefs.SetInt("MediaQTD_RT", 0);
                }

                rtController.GameOver();
                lineGraph.SetActive(true);


                SaveList();
                LoadList();
                PostInfo();

            }
        }
    }
    private void PostInfo()
    {
        StartCoroutine(UnityToForm.enviarForm.PostRt(UnityToForm.enviarForm.Cpf));
    }
    public void SaveList()
    {
        PlayerPrefs.SetFloat("Media_RT" + PlayerPrefs.GetInt("MediaQTD_RT"), Avg);
    }

    public void LoadList()
    {
        mediaList.Clear();
        GeneralCount = PlayerPrefs.GetInt("MediaQTD_RT");
        for (int i = 0; i < PlayerPrefs.GetInt("MediaQTD_RT") + 1; i++)
        {
            float media = PlayerPrefs.GetFloat("Media_RT" + i);
            mediaList.Add(media);
            Debug.Log("Media_" + i + ": " + mediaList[i]);
        }
    }
}
